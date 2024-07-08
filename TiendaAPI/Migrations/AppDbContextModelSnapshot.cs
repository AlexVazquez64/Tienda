﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaAPI.Data;

#nullable disable

namespace TiendaAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TiendaAPI.Entities.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Imagen")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("TiendaAPI.Entities.ArticuloTienda", b =>
                {
                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId", "TiendaId");

                    b.HasIndex("TiendaId");

                    b.ToTable("ArticulosTienda");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Compra", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("ClienteId", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Tiendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TiendaAPI.Entities.ArticuloTienda", b =>
                {
                    b.HasOne("TiendaAPI.Entities.Articulo", "Articulo")
                        .WithMany("ArticulosTienda")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Entities.Tiendas", "Tienda")
                        .WithMany("ArticulosTienda")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Compra", b =>
                {
                    b.HasOne("TiendaAPI.Entities.Articulo", "Articulo")
                        .WithMany("Compras")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Entities.Cliente", "Cliente")
                        .WithMany("Compras")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Articulo", b =>
                {
                    b.Navigation("ArticulosTienda");

                    b.Navigation("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Cliente", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Entities.Tiendas", b =>
                {
                    b.Navigation("ArticulosTienda");
                });
#pragma warning restore 612, 618
        }
    }
}
