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
    
    public partial class REQUEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REQUEST()
        {
            this.INCLUDE = new HashSet<INCLUDE>();
        }
    
        public string ID_REQUEST { get; set; }
        public string ID_SUPPLIER { get; set; }
        public string ID_EMPLOYEE { get; set; }
        public System.DateTime REQUEST_DATE { get; set; }
        public Nullable<System.DateTime> DELIVERY_DATE { get; set; }
        public decimal CONFORMITY { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public string UNIT_NUMBER { get; set; }
        public string REPRESENTATIVE { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INCLUDE> INCLUDE { get; set; }
        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}