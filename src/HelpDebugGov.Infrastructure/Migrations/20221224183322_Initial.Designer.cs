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
    [Migration("20221224183322_Initial")]
    partial class Initial
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
                            Id = new Guid("e7090000-ac14-0242-8f40-08dae5dd5500"),
                            Action = "User",
                            Description = "All permissions in `User` scope"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-9d2c-08dae5dd5500"),
                            Action = "User.Read",
                            Description = "Read `User` data"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-9d7e-08dae5dd5500"),
                            Action = "User.Delete",
                            Description = "Delete `User` data"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-9d84-08dae5dd5500"),
                            Action = "User.Create",
                            Description = "Create `User` data"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-9d89-08dae5dd5500"),
                            Action = "User.Update",
                            Description = "Update `User` data"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-9d92-08dae5dd5500"),
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
                        .HasMaxLength(63)
                        .HasColumnType("character varying(63)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-25ba-08dae5dd5501"),
                            Description = "Any logged-in user",
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("e7090000-ac14-0242-2a54-08dae5dd5501"),
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
                            Id = new Guid("e7090000-ac14-0242-4eb3-08dae5dd554d"),
                            Email = "tangimhossain1@gmail.com",
                            Handle = "audacioustux",
                            Name = "Audacious Tux",
                            Password = "$2a$11$1TlORiQWp81dlHBjzXUAHeyi60AEZtb8w26.pLTR/untsPVlufWSK"
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
                            PermissionsId = new Guid("e7090000-ac14-0242-9d92-08dae5dd5500"),
                            RolesId = new Guid("e7090000-ac14-0242-2a54-08dae5dd5501")
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
                            RolesId = new Guid("e7090000-ac14-0242-2a54-08dae5dd5501"),
                            UsersId = new Guid("e7090000-ac14-0242-4eb3-08dae5dd554d")
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