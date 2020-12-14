using emb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emb.ViewModels
{
    public class OrdenViewModel
    {
        public int OrdenId { get; set; }

        public List<DetalleOrden> DetallesOrden { get; set; }

        public string NombreCliente { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        public double TotalOrden { get; set; }

        public DateTime FechaCompra { get; set; }
    }
}
