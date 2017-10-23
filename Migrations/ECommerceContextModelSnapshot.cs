using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ECommerce.Models;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("ECommerce.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<int>("customerid");

                    b.Property<int>("productid");

                    b.Property<int>("quantity");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.HasIndex("customerid");

                    b.HasIndex("productid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerce.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("description");

                    b.Property<string>("img_url");

                    b.Property<string>("name");

                    b.Property<int>("quantity");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.HasOne("ECommerce.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
