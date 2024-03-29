﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderSystem.Repository;

namespace OrderSystem.Migrations
{
    [DbContext(typeof(OrdersDBContext))]
    [Migration("20190911101713_intialization")]
    partial class intialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderSystem.Model.Core.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderStatus");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderSystem.Model.Core.Orders", b =>
                {
                    b.OwnsOne("OrderSystem.Model.Core.OrderDateTime", "OrderDate", b1 =>
                        {
                            b1.Property<int>("OrdersOrderId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("OrderDate")
                                .HasColumnName("OrderDate");

                            b1.HasKey("OrdersOrderId");

                            b1.ToTable("Orders");

                            b1.HasOne("OrderSystem.Model.Core.Orders")
                                .WithOne("OrderDate")
                                .HasForeignKey("OrderSystem.Model.Core.OrderDateTime", "OrdersOrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsMany("OrderSystem.Model.Core.OrderItems", "OrderItems", b1 =>
                        {
                            b1.Property<int>("OrderLineItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("OrderLineItemId")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("OrderId");

                            b1.Property<int>("ProductID")
                                .HasColumnName("ProductID");

                            b1.Property<int>("ProductPrice")
                                .HasColumnName("ProductPrice");

                            b1.Property<int>("ProductQuantity")
                                .HasColumnName("ProductQuantity");

                            b1.HasKey("OrderLineItemId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderItems");

                            b1.HasOne("OrderSystem.Model.Core.Orders")
                                .WithMany("OrderItems")
                                .HasForeignKey("OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
