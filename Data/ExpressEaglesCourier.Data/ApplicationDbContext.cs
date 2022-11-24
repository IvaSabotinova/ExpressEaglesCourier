namespace ExpressEaglesCourier.Data
{
    using System;
    using System.Diagnostics.Metrics;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Reflection.Metadata;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Models;
    using ExpressEaglesCourier.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ShipmentTrackingPath> ShipmentsTrackingPath { get; set; }

        public DbSet<EmployeeShipment> EmployeesShipments { get; set; }

        public DbSet<ShipmentVehicle> ShipmentsVehicles { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeShipment>()
                .HasKey(x => new { x.EmployeeId, x.ShipmentId });

            builder.Entity<ShipmentVehicle>()
               .HasKey(x => new { x.ShipmentId, x.VehicleId });

            builder.Entity<Shipment>()
            .HasOne(x => x.ShipmentTrackingPath)
            .WithOne(x => x.Shipment)
            .HasForeignKey<ShipmentTrackingPath>(st => st.ShipmentId);

            builder.Entity<Shipment>()
            .HasMany(x => x.Feedbacks)
            .WithOne(x => x.Shipment)
            .IsRequired(false);

            builder.Entity<EmployeeShipment>()
            .HasOne<Employee>(x => x.Employee)
            .WithMany(x => x.EmployeesShipments)
            .HasForeignKey(x => x.EmployeeId)
            .IsRequired(false);

            builder.Entity<EmployeeShipment>()
            .HasOne<Shipment>(x => x.Shipment)
            .WithMany(x => x.EmployeesShipments)
            .HasForeignKey(x => x.ShipmentId)
            .IsRequired(false);

            builder.Entity<ShipmentVehicle>()
           .HasOne<Shipment>(x => x.Shipment)
           .WithMany(x => x.ShipmentsVehicles)
           .HasForeignKey(x => x.ShipmentId)
           .IsRequired(false);

            builder.Entity<ShipmentVehicle>()
            .HasOne<Vehicle>(x => x.Vehicle)
            .WithMany(x => x.ShipmentsVehicles)
            .HasForeignKey(x => x.VehicleId)
            .IsRequired(false);

            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
