﻿// <auto-generated />
using System;
using BackEnd.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.DataBase.Migrations.Production
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20190729124031_AddUniqueueAndRequiredField")]
    partial class AddUniqueueAndRequiredField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Models.RegisterTokenPair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("RegisterTokenPairs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.DataBaseLinks.PlaceEquipment", b =>
                {
                    b.Property<Guid>("EquipmentId");

                    b.Property<Guid>("PlaceId");

                    b.HasKey("EquipmentId", "PlaceId");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceEquipment");
                });

            modelBuilder.Entity("Models.DataBaseLinks.PlaceUserEventRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("PlaceId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime?>("DoneTime");

                    b.Property<Guid>("EventRoleId");

                    b.Property<int>("UserStatus");

                    b.HasKey("UserId", "PlaceId");

                    b.HasIndex("EventRoleId");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceUserEventRole");
                });

            modelBuilder.Entity("Models.Equipments.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("EquipmentTypeId");

                    b.Property<int>("Number");

                    b.Property<Guid?>("OwnerId");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Models.Equipments.EquipmentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Deep");

                    b.Property<string>("Description");

                    b.Property<int>("LastNumber");

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid?>("RootId");

                    b.Property<string>("ShortTitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("RootId");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("Models.Events.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BeginTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<Guid>("EventTypeId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Models.Events.EventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Models.Events.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("ShiftId");

                    b.Property<int>("TargetParticipantsCount");

                    b.HasKey("Id");

                    b.HasIndex("ShiftId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Models.Events.Roles.EventRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EventRoles");
                });

            modelBuilder.Entity("Models.Events.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<Guid>("EventId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("Models.People.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Token");

                    b.Property<string>("UserAgent");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Models.People.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Models.People.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.People.UserProperties.UserProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<Guid>("UserId");

                    b.Property<Guid>("UserPropertyTypeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserPropertyTypeId");

                    b.ToTable("UserProperties");
                });

            modelBuilder.Entity("Models.People.UserProperties.UserPropertyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DefaultStatus");

                    b.Property<string>("Description");

                    b.Property<string>("InternalName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("InternalName")
                        .IsUnique();

                    b.ToTable("UserPropertyTypes");
                });

            modelBuilder.Entity("Models.People.UserSetting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<Guid>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Models.People.Roles.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Models.People.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Models.People.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Models.People.Roles.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.People.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Models.People.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.DataBaseLinks.PlaceEquipment", b =>
                {
                    b.HasOne("Models.Equipments.Equipment", "Equipment")
                        .WithMany("PlaceEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Events.Place", "Place")
                        .WithMany("PlaceEquipments")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.DataBaseLinks.PlaceUserEventRole", b =>
                {
                    b.HasOne("Models.Events.Roles.EventRole", "EventRole")
                        .WithMany("PlaceUserEventRoles")
                        .HasForeignKey("EventRoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Events.Place", "Place")
                        .WithMany("PlaceUserEventRoles")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.People.User", "User")
                        .WithMany("PlaceUserEventRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Equipments.Equipment", b =>
                {
                    b.HasOne("Models.Equipments.EquipmentType", "EquipmentType")
                        .WithMany("Equipment")
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.People.User", "Owner")
                        .WithMany("Equipment")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Models.Equipments.Equipment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Models.Equipments.EquipmentType", b =>
                {
                    b.HasOne("Models.Equipments.EquipmentType", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Models.Equipments.EquipmentType", "Root")
                        .WithMany("AllChildren")
                        .HasForeignKey("RootId");
                });

            modelBuilder.Entity("Models.Events.Event", b =>
                {
                    b.HasOne("Models.Events.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Events.Place", b =>
                {
                    b.HasOne("Models.Events.Shift", "Shift")
                        .WithMany("Places")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Events.Shift", b =>
                {
                    b.HasOne("Models.Events.Event", "Event")
                        .WithMany("Shifts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.People.RefreshToken", b =>
                {
                    b.HasOne("Models.People.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.People.UserProperties.UserProperty", b =>
                {
                    b.HasOne("Models.People.User", "User")
                        .WithMany("UserProperties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.People.UserProperties.UserPropertyType", "UserPropertyType")
                        .WithMany("UserProperties")
                        .HasForeignKey("UserPropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.People.UserSetting", b =>
                {
                    b.HasOne("Models.People.User", "User")
                        .WithMany("UserSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
