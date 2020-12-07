﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emb.Context;

namespace emb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201207205606_nueva")]
    partial class nueva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("emb.Models.Carrito", b =>
                {
                    b.Property<string>("CarritoId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("CarritoId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("emb.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("emb.Models.DetalleOrden", b =>
                {
                    b.Property<int>("DetalleOrdenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("OrdenId");

                    b.Property<double>("Precio");

                    b.Property<int>("ProductoId");

                    b.HasKey("DetalleOrdenId");

                    b.HasIndex("OrdenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesOrden");
                });

            modelBuilder.Entity("emb.Models.ItemCarrito", b =>
                {
                    b.Property<int>("ItemCarritoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<string>("CarritoId");

                    b.Property<int?>("ProductoId");

                    b.HasKey("ItemCarritoId");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ItemsCarrito");
                });

            modelBuilder.Entity("emb.Models.Orden", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad");

                    b.Property<string>("Direccion");

                    b.Property<string>("Email");

                    b.Property<DateTime>("FechaCompra");

                    b.Property<string>("NombreCliente");

                    b.Property<int>("Telefono");

                    b.Property<double>("TotalOrden");

                    b.HasKey("OrdenId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("emb.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Nombre");

                    b.Property<double>("Precio");

                    b.Property<int>("Stock");

                    b.Property<string>("URLImagen");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("emb.Models.DetalleOrden", b =>
                {
                    b.HasOne("emb.Models.Orden", "Orden")
                        .WithMany("DetallesOrden")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("emb.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("emb.Models.ItemCarrito", b =>
                {
                    b.HasOne("emb.Models.Carrito")
                        .WithMany("ItemsCarrito")
                        .HasForeignKey("CarritoId");

                    b.HasOne("emb.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");
                });

            modelBuilder.Entity("emb.Models.Producto", b =>
                {
                    b.HasOne("emb.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
