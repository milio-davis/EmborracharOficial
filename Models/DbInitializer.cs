using emb.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(Categorias.Select(c => c.Value));
            }

            var user = new IdentityUser() { UserName = "ASD" };

            if (!context.Cuentas.Any())
            {
                context.Cuentas.AddRange(
                    new Cuenta
                    {
                        Username = "ASD",
                        Password = "123"
                    });
                
            }

            if (!context.Productos.Any())
            {
                context.AddRange
                (
                    new Producto
                    {
                        Nombre = "Quilmes",
                        Precio = 2.8,
                        Categoria = Categorias["Cervezas"],
                        URLImagen = "",
                        Stock = 30
                    },
                    new Producto
                    {
                        Nombre = "Trapiche",
                        Precio = 2458,
                        Categoria = Categorias["Vinos"],
                        URLImagen = "",
                        Stock = 40
                    },
                    new Producto
                    {
                        Nombre = "Whisky Dios",
                        Precio = 238,
                        Categoria = Categorias["Whiskies"],
                        URLImagen = "",
                        Stock = 1
                    }
                    ,
                    new Producto
                    {
                        Nombre = "420",
                        Precio = 238,
                        Categoria = Categorias["Whiskies"],
                        URLImagen = "~/images/bebidas/black label.jpg",
                        Stock = 1
                    },
                    new Producto
                    {
                        Nombre = "Gaggager",
                        Precio = 238,
                        Categoria = Categorias["Vinos"],
                        URLImagen = "",
                        Stock = 1
                    }

                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Categoria> categorias;
        public static Dictionary<string, Categoria> Categorias
        {
            get
            {
                if (categorias == null)
                {
                    var genresList = new Categoria[]
                    {
                        new Categoria { Nombre = "Cervezas"},
                        new Categoria { Nombre = "Vinos"},
                        new Categoria { Nombre = "Whiskies"}
                    };

                    categorias = new Dictionary<string, Categoria>();

                    foreach (Categoria genre in genresList)
                    {
                        categorias.Add(genre.Nombre, genre);
                    }
                }

                return categorias;
            }
        }
    }
}