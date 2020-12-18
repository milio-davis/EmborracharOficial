using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emb.Models
{
    public class Orden
    {
        [BindNever]
        
        public int OrdenId { get; set; }
        public List<DetalleOrden> DetallesOrden { get; set; }

        [Required(ErrorMessage = "Ingresar nombre")]
        [Display(Name = "Nombre")]
        [StringLength(70)]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Ingresar direccion")]
        [StringLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Ingresar telefono")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "El email no fue ingresado en un formato correcto")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public double TotalOrden { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime FechaCompra { get; set; }
    }
}