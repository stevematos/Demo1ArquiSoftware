//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETAIL
    {
        public string ID_PRODUCT { get; set; }
        public string ID_SALE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal SALE_PRICE { get; set; }
        public decimal DISCOUNT { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual SALE SALE { get; set; }
    }
}
