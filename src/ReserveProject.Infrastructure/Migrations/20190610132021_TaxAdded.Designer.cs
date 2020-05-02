﻿// <auto-generated />
using System;
using ReserveProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ReserveProject.Infrastructure.Migrations
{
    [DbContext(typeof(PrimeDbContext))]
    [Migration("20190610132021_TaxAdded")]
    partial class TaxAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReserveProject.Domain.Aggregates.CustomerAggregate.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<int>("EntityStatus");

                    b.Property<DateTimeOffset>("LastChangeDate");

                    b.Property<string>("Name");

                    b.Property<Guid>("UId");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ReserveProject.Domain.Aggregates.TaxAggregate.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Computation");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<int>("EntityStatus");

                    b.Property<DateTimeOffset>("LastChangeDate");

                    b.Property<string>("Name");

                    b.Property<int>("Scope");

                    b.Property<Guid>("UId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("Tax");
                });

            modelBuilder.Entity("ReserveProject.Shared.Logging.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<string>("Data");

                    b.Property<Guid>("EntityId");

                    b.Property<bool>("ProcessedByJob");

                    b.Property<string>("RemoteIp");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Events","Event");
                });
#pragma warning restore 612, 618
        }
    }
}
