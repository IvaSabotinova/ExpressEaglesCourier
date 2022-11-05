﻿// <auto-generated />
using System;
using ExpressEaglesCourier.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeShipment", b =>
                {
                    b.Property<string>("EmployeesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShipmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeesId", "ShipmentsId");

                    b.HasIndex("ShipmentsId");

                    b.ToTable("EmployeeShipment");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasComment("Home address");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The Id of the Customer should he/she become user of the site");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)")
                        .HasComment("Home city");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("The name of the company should shipment is ordered by a company");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("Home country");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasComment("Home address");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The id of the Employee when he/she becomes user of the site.");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)")
                        .HasComment("Home city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("Home country");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("HiredOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date on which the employee was hired.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("OfficeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ResignOn")
                        .HasColumnType("datetime2")
                        .HasComment("The date on which the employee resigns / retires.");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The vehicle used by the employee courier.");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(7000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Content of the feedback of a customer concerning particular shipment.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The id of the customer that provided his/her feedback.");

                    b.Property<bool>("IsPositive")
                        .HasColumnType("bit")
                        .HasComment("A value indicating whether customer's feedback is positive.");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The id of the shipment that the feedback refers to.");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Office", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(330)
                        .HasColumnType("nvarchar(330)");

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Shipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShipmentTrackingPathId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.ShipmentTrackingPath", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ArrivalInReceivingOffice")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of shipment arrival in receiving office.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FinalDelivery")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of shipment's final delivery / handover to customer.");

                    b.Property<DateTime?>("FinalDeliveryPreparation")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of shipment final processing / preparation for final delivery to customer.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PickedUpByCourier")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of picking up shipment from customer.");

                    b.Property<DateTime?>("SentFromDispatchingOffice")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of sending shipment from dispatching office.");

                    b.Property<string>("ShipmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The shipment that tracking path is related to.");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("ShipmentId")
                        .IsUnique();

                    b.ToTable("ShipmentsTrackingPath");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The employee that uses the vehicle.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("IsDeleted");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShipmentVehicle", b =>
                {
                    b.Property<string>("ShipmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VehiclesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ShipmentsId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("ShipmentVehicle");
                });

            modelBuilder.Entity("EmployeeShipment", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpressEaglesCourier.Data.Models.Shipment", null)
                        .WithMany()
                        .HasForeignKey("ShipmentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.City", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Customer", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Customer")
                        .HasForeignKey("ExpressEaglesCourier.Data.Models.Customer", "ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Employee", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Employee")
                        .HasForeignKey("ExpressEaglesCourier.Data.Models.Employee", "ApplicationUserId");

                    b.HasOne("ExpressEaglesCourier.Data.Models.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpressEaglesCourier.Data.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Office");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Feedback", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Customer", "Customer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ExpressEaglesCourier.Data.Models.Shipment", "Shipment")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ShipmentId");

                    b.Navigation("Customer");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Office", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.City", "City")
                        .WithMany("Offices")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Shipment", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Customer", "Receiver")
                        .WithMany("ReceivedShipments")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpressEaglesCourier.Data.Models.Customer", "Sender")
                        .WithMany("SentShipments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.ShipmentTrackingPath", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Shipment", "Shipment")
                        .WithOne("ShipmentTrackingPath")
                        .HasForeignKey("ExpressEaglesCourier.Data.Models.ShipmentTrackingPath", "ShipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Vehicle", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Employee", "Employee")
                        .WithOne("Vehicle")
                        .HasForeignKey("ExpressEaglesCourier.Data.Models.Vehicle", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ShipmentVehicle", b =>
                {
                    b.HasOne("ExpressEaglesCourier.Data.Models.Shipment", null)
                        .WithMany()
                        .HasForeignKey("ShipmentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExpressEaglesCourier.Data.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Logins");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.City", b =>
                {
                    b.Navigation("Offices");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Customer", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("ReceivedShipments");

                    b.Navigation("SentShipments");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Employee", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ExpressEaglesCourier.Data.Models.Shipment", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("ShipmentTrackingPath");
                });
#pragma warning restore 612, 618
        }
    }
}
