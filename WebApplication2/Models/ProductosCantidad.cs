using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ProductosCantidad
    {
        public string idproducto { get; set; }
        public int cantidad { get; set; }
        public ProductosCantidad(string idproducto , int cantidad)
        {
            this.idproducto = idproducto;
            this.cantidad = cantidad;
        }
    }
}