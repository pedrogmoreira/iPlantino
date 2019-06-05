﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrate;

namespace MigrateAzure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190605194024_DeviceFix")]
    partial class DeviceFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iPlantino.Domain.AggregatesModel.PermissionAggregate.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("permission","identity");
                });

            modelBuilder.Entity("iPlantino.Domain.Device.Models.Arduino", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusion_date")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("MacAdrress")
                        .IsRequired()
                        .HasColumnName("mac_address")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("Observation")
                        .HasColumnName("observation")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("arduino","device");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Arduino");
                });

            modelBuilder.Entity("iPlantino.Domain.Device.Models.ArduinoHumidity", b =>
                {
                    b.Property<Guid>("ArduinoId")
                        .HasColumnName("arduino_id");

                    b.Property<Guid>("HumidityId")
                        .HasColumnName("humidity_id");

                    b.HasKey("ArduinoId", "HumidityId");

                    b.HasIndex("ArduinoId")
                        .HasName("arduino_has_humidity_id_index");

                    b.HasIndex("HumidityId");

                    b.ToTable("arduino_has_humidity","device");
                });

            modelBuilder.Entity("iPlantino.Domain.Device.Models.Humidity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusion_date")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<double>("Measurement")
                        .HasColumnName("measurement");

                    b.HasKey("Id");

                    b.ToTable("humidity","device");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("user_claim_id_index");

                    b.ToTable("user_claim","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId")
                        .HasName("user_login_id_index");

                    b.ToTable("user_login","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .HasName("user_role_id_index");

                    b.ToTable("user_role","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("role_normalize_name_index")
                        .HasFilter("[normalized_name] IS NOT NULL");

                    b.ToTable("role","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .HasName("role_claims_id_index");

                    b.ToTable("role_claims","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lockout_end")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(60);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_username")
                        .HasMaxLength(30);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("username")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("email_index");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("user_normalized_name_index")
                        .HasFilter("[normalized_username] IS NOT NULL");

                    b.ToTable("user","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUserArduino", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("ArduinoId")
                        .HasColumnName("arduino_id");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "ArduinoId");

                    b.HasIndex("ArduinoId")
                        .IsUnique()
                        .HasName("user_arduino_id_index");

                    b.ToTable("user_arduino","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_token","identity");
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationArduino", b =>
                {
                    b.HasBaseType("iPlantino.Domain.Device.Models.Arduino");

                    b.ToTable("arduino","device");

                    b.HasDiscriminator().HasValue("ApplicationArduino");
                });

            modelBuilder.Entity("iPlantino.Domain.Device.Models.ArduinoHumidity", b =>
                {
                    b.HasOne("iPlantino.Domain.Device.Models.Arduino", "Arduino")
                        .WithMany("ArduinoHumidities")
                        .HasForeignKey("ArduinoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iPlantino.Domain.Device.Models.Humidity", "Humidity")
                        .WithMany("ArduinoHumidities")
                        .HasForeignKey("HumidityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserClaim", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserLogin", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.AplicationUserRole", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUserArduino", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationArduino", "Arduino")
                        .WithOne("UserArduino")
                        .HasForeignKey("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUserArduino", "ArduinoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserArduinos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("iPlantino.Infra.CrossCutting.Identity.Entities.ApplicationUser", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
