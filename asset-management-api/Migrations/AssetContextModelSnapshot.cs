﻿// <auto-generated />
using System;
using AssetManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetManagement.Migrations
{
    [DbContext(typeof(AssetContext))]
    partial class AssetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssetManagement.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"));

                    b.Property<string>("AssetOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetsGroupID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommissionedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DisposalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisposalReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Feeder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GXP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubZoneID")
                        .HasColumnType("int");

                    b.HasKey("AssetId");

                    b.HasIndex("AssetsGroupID");

                    b.HasIndex("SubZoneID");

                    b.ToTable("Assets", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.AssetsGroup", b =>
                {
                    b.Property<string>("AssetsGroupID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CustomersCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetsGroupID");

                    b.ToTable("AssetsGroup", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.BatteryBank", b =>
                {
                    b.Property<int>("BatteryBankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatteryBankId"));

                    b.Property<int>("AssetID")
                        .HasColumnType("int");

                    b.Property<string>("BatteryBankCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatteryBankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatteryBankType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatteryBankVoltage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BatteryBankId");

                    b.HasIndex("AssetID")
                        .IsUnique();

                    b.ToTable("BatteryBank", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.Cable", b =>
                {
                    b.Property<int>("CableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CableId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetID")
                        .HasColumnType("int");

                    b.Property<string>("CableLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CableRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CableVoltage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPhases")
                        .HasColumnType("int");

                    b.Property<int>("RegLife")
                        .HasColumnType("int");

                    b.HasKey("CableId");

                    b.HasIndex("AssetID")
                        .IsUnique();

                    b.ToTable("Cable", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.PillerBox", b =>
                {
                    b.Property<int>("PillerBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PillerBoxId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line_segment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PillerBoxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PillerBoxId");

                    b.HasIndex("AssetId")
                        .IsUnique();

                    b.ToTable("PillerBox", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.Pole", b =>
                {
                    b.Property<int>("PoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoleId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoleHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoleMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoleType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegLife")
                        .HasColumnType("int");

                    b.HasKey("PoleId");

                    b.HasIndex("AssetId")
                        .IsUnique();

                    b.ToTable("Pole", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.SubZone", b =>
                {
                    b.Property<int>("SubZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubZoneId"));

                    b.Property<string>("LatestAnnualRecordID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatestBiMonthRecordID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalCouncil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubZoneCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubZoneDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubZoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubZoneId");

                    b.ToTable("SubZone", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.Substation", b =>
                {
                    b.Property<int>("SubstationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubstationId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetID")
                        .HasColumnType("int");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputVotage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inspactby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastInspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OutputVotage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubstationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubstationId");

                    b.HasIndex("AssetID")
                        .IsUnique();

                    b.ToTable("Substation", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Models.Transformer", b =>
                {
                    b.Property<int>("TransformerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransformerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetID")
                        .HasColumnType("int");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputVotage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutputVotage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegLife")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransformerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransformerId");

                    b.HasIndex("AssetID")
                        .IsUnique();

                    b.ToTable("Transformer", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.HasOne("AssetManagement.Models.AssetsGroup", "AssetsGroup")
                        .WithMany("Assets")
                        .HasForeignKey("AssetsGroupID");

                    b.HasOne("AssetManagement.Models.SubZone", "SubZone")
                        .WithMany("Assets")
                        .HasForeignKey("SubZoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetsGroup");

                    b.Navigation("SubZone");
                });

            modelBuilder.Entity("AssetManagement.Models.BatteryBank", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("batteryBank")
                        .HasForeignKey("AssetManagement.Models.BatteryBank", "AssetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Cable", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("cable")
                        .HasForeignKey("AssetManagement.Models.Cable", "AssetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.PillerBox", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("pillerBox")
                        .HasForeignKey("AssetManagement.Models.PillerBox", "AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Pole", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("pole")
                        .HasForeignKey("AssetManagement.Models.Pole", "AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Substation", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("substation")
                        .HasForeignKey("AssetManagement.Models.Substation", "AssetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Transformer", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithOne("Transformer")
                        .HasForeignKey("AssetManagement.Models.Transformer", "AssetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AssetManagement.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AssetManagement.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AssetManagement.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.Navigation("Transformer");

                    b.Navigation("batteryBank");

                    b.Navigation("cable");

                    b.Navigation("pillerBox");

                    b.Navigation("pole");

                    b.Navigation("substation");
                });

            modelBuilder.Entity("AssetManagement.Models.AssetsGroup", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetManagement.Models.SubZone", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
