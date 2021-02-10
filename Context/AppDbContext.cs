using emb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItemCarrito> ItemsCarrito { get; set; }        

        public DbSet<Orden> Ordenes { get; set; }

        public DbSet<DetalleOrden> DetallesOrden { get; set; }

        public DbSet<Cuenta> Cuentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            _ = modelBuilder.Entity<Orden>()

            .HasKey(b => b.OrdenId);
           
            modelBuilder.Entity<DetalleOrden>()
            .HasOne(p => p.Orden)
            .WithMany(b => b.DetallesOrden).OnDelete(DeleteBehavior.Restrict);           
          }
    }
}
