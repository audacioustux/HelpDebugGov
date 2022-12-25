﻿// <auto-generated />
using System;
using HelpDebugGov.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelpDebugGov.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221225101045_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "ltree");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HelpDebugGov.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("ltree");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("Action")
                        .IsUnique();

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-fac8-08dae66048f7"),
                            Action = "User",
                            Description = "All permissions in `User` scope"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1c68-08dae66048f8"),
                            Action = "User.Read",
                            Description = "Read `User` data"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1cc5-08dae66048f8"),
                            Action = "User.Read.ById",
                            Description = "Read `User` data by Id"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1ccb-08dae66048f8"),
                            Action = "User.Delete",
                            Description = "Delete `User` data"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1cd0-08dae66048f8"),
                            Action = "User.Create",
                            Description = "Create `User` data"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1cd4-08dae66048f8"),
                            Action = "User.Update",
                            Description = "Update `User` data"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-1cdc-08dae66048f8"),
                            Action = "_",
                            Description = "All permissions"
                        });
                });

            modelBuilder.Entity("HelpDebugGov.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(31)
                        .HasColumnType("character varying(31)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-8fe0-08dae66048f8"),
                            Description = "Any logged-in user",
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-9509-08dae66048f8"),
                            Description = "Has all permissions",
                            Name = "Superuser"
                        });
                });

            modelBuilder.Entity("HelpDebugGov.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Handle")
                        .HasMaxLength(31)
                        .HasColumnType("character varying(31)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("character varying(127)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Handle")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25180000-ac14-0242-a029-08dae6604931"),
                            Email = "tangimhossain1@gmail.com",
                            Handle = "audacioustux",
                            Name = "Audacious Tux",
                            Password = "$2a$11$CZHFgSpXcqTY9ZSH26gGQuGFBv27z8KknzjWolZUIJ04ATnBXgcxW"
                        });
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<Guid>("PermissionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");

                    b.HasData(
                        new
                        {
                            PermissionsId = new Guid("25180000-ac14-0242-1cdc-08dae66048f8"),
                            RolesId = new Guid("25180000-ac14-0242-9509-08dae66048f8")
                        });
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.Property<Guid>("PermissionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("PermissionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PermissionUser");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");

                    b.HasData(
                        new
                        {
                            RolesId = new Guid("25180000-ac14-0242-9509-08dae66048f8"),
                            UsersId = new Guid("25180000-ac14-0242-a029-08dae6604931")
                        });
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("HelpDebugGov.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpDebugGov.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.HasOne("HelpDebugGov.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpDebugGov.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("HelpDebugGov.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpDebugGov.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}