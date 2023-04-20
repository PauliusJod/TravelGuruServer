﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelGuruServer.Data;

#nullable disable

namespace TravelGuruServer.Migrations
{
    [DbContext(typeof(TravelDBContext))]
    [Migration("20230419165206_RouteMigrations")]
    partial class RouteMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("TravelGuruServer.Auth.Model.TravelUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("TravelGuruServer.Entities.AdditionalPoints", b =>
                {
                    b.Property<int>("additionalPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("additionalPointId"), 1L, 1);

                    b.Property<int?>("TroutePointDescriptionpointId")
                        .HasColumnType("int");

                    b.Property<int?>("TrouteSectionDescriptionsectionId")
                        .HasColumnType("int");

                    b.Property<float>("additionalPointCoordX")
                        .HasColumnType("real");

                    b.Property<float>("additionalPointCoordY")
                        .HasColumnType("real");

                    b.Property<string>("additionalPointInformation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("additionalPointId");

                    b.HasIndex("TroutePointDescriptionpointId");

                    b.HasIndex("TrouteSectionDescriptionsectionId");

                    b.ToTable("AdditionalPoints");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.MidWaypoint", b =>
                {
                    b.Property<int>("midWaypointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("midWaypointId"), 1L, 1);

                    b.Property<int?>("TRoutePrivaterouteId")
                        .HasColumnType("int");

                    b.Property<int?>("TRoutePublicrouteId")
                        .HasColumnType("int");

                    b.Property<string>("midWaypointLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("midWaypointStopover")
                        .HasColumnType("bit");

                    b.HasKey("midWaypointId");

                    b.HasIndex("TRoutePrivaterouteId");

                    b.HasIndex("TRoutePublicrouteId");

                    b.ToTable("MidWaypoints");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TroutePointDescription", b =>
                {
                    b.Property<int>("pointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pointId"), 1L, 1);

                    b.Property<int?>("TRoutePrivaterouteId")
                        .HasColumnType("int");

                    b.Property<int?>("TRoutePublicrouteId")
                        .HasColumnType("int");

                    b.Property<int>("pointOnRouteId")
                        .HasColumnType("int");

                    b.Property<string>("routePointDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pointId");

                    b.HasIndex("TRoutePrivaterouteId");

                    b.HasIndex("TRoutePublicrouteId");

                    b.ToTable("TroutePointDescriptions");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePrivate", b =>
                {
                    b.Property<int>("routeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("routeId"), 1L, 1);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("rCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rDestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rImagesUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rRecommendationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("routeId");

                    b.HasIndex("UserId");

                    b.ToTable("TRoutesPrivate");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePublic", b =>
                {
                    b.Property<int>("routeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("routeId"), 1L, 1);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("rCost")
                        .HasColumnType("float");

                    b.Property<string>("rCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rDestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rImagesUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("rRating")
                        .HasColumnType("real");

                    b.Property<string>("rRecommendationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("routeId");

                    b.HasIndex("UserId");

                    b.ToTable("TRoutesPublic");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TrouteSectionDescription", b =>
                {
                    b.Property<int>("sectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sectionId"), 1L, 1);

                    b.Property<int?>("TRoutePrivaterouteId")
                        .HasColumnType("int");

                    b.Property<int?>("TRoutePublicrouteId")
                        .HasColumnType("int");

                    b.Property<string>("routeSectionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sectionOnRouteId")
                        .HasColumnType("int");

                    b.HasKey("sectionId");

                    b.HasIndex("TRoutePrivaterouteId");

                    b.HasIndex("TRoutePublicrouteId");

                    b.ToTable("TrouteSectionDescriptions");
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
                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", null)
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

                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelGuruServer.Entities.AdditionalPoints", b =>
                {
                    b.HasOne("TravelGuruServer.Entities.TroutePointDescription", null)
                        .WithMany("AddinionalPointMarks")
                        .HasForeignKey("TroutePointDescriptionpointId");

                    b.HasOne("TravelGuruServer.Entities.TrouteSectionDescription", null)
                        .WithMany("AddinionalSectionPoints")
                        .HasForeignKey("TrouteSectionDescriptionsectionId");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.MidWaypoint", b =>
                {
                    b.HasOne("TravelGuruServer.Entities.TRoutePrivate", null)
                        .WithMany("MidWaypoint")
                        .HasForeignKey("TRoutePrivaterouteId");

                    b.HasOne("TravelGuruServer.Entities.TRoutePublic", null)
                        .WithMany("MidWaypoint")
                        .HasForeignKey("TRoutePublicrouteId");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TroutePointDescription", b =>
                {
                    b.HasOne("TravelGuruServer.Entities.TRoutePrivate", null)
                        .WithMany("TroutePointDescription")
                        .HasForeignKey("TRoutePrivaterouteId");

                    b.HasOne("TravelGuruServer.Entities.TRoutePublic", null)
                        .WithMany("TroutePointDescription")
                        .HasForeignKey("TRoutePublicrouteId");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePrivate", b =>
                {
                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePublic", b =>
                {
                    b.HasOne("TravelGuruServer.Auth.Model.TravelUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TrouteSectionDescription", b =>
                {
                    b.HasOne("TravelGuruServer.Entities.TRoutePrivate", null)
                        .WithMany("TrouteSectionDescription")
                        .HasForeignKey("TRoutePrivaterouteId");

                    b.HasOne("TravelGuruServer.Entities.TRoutePublic", null)
                        .WithMany("TrouteSectionDescription")
                        .HasForeignKey("TRoutePublicrouteId");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TroutePointDescription", b =>
                {
                    b.Navigation("AddinionalPointMarks");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePrivate", b =>
                {
                    b.Navigation("MidWaypoint");

                    b.Navigation("TroutePointDescription");

                    b.Navigation("TrouteSectionDescription");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TRoutePublic", b =>
                {
                    b.Navigation("MidWaypoint");

                    b.Navigation("TroutePointDescription");

                    b.Navigation("TrouteSectionDescription");
                });

            modelBuilder.Entity("TravelGuruServer.Entities.TrouteSectionDescription", b =>
                {
                    b.Navigation("AddinionalSectionPoints");
                });
#pragma warning restore 612, 618
        }
    }
}