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
    public class AppDbContext : IdentityDbContext<IdentityUser>
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
            modelBuilder.Entity<DetalleOrden>()
                .HasOne(p => p.Orden)
                .WithMany(b => b.DetallesOrden);
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>()
                .HasMany(b => b.DetallesOrden)
                .WithOne();
        }
        */
    }
}
