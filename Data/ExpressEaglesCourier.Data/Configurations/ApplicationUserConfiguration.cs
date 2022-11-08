namespace ExpressEaglesCourier.Data.Configurations
{
    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
        {
            appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
              .HasOne(x => x.Customer)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey<Customer>(x => x.ApplicationUserId);

            appUser
             .HasOne(x => x.Employee)
             .WithOne(x => x.ApplicationUser)
             .HasForeignKey<Employee>(x => x.ApplicationUserId);
        }
    }
}
