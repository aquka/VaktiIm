//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VaktiImProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class POROSI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POROSI()
        {
            this.POROSI_ITEM = new HashSet<POROSI_ITEM>();
        }
    
        public int porosi_id { get; set; }
        public int adresa_id { get; set; }
        public System.DateTime datetime_Porosi { get; set; }
        public bool status_porosie { get; set; }
        public int klient_id { get; set; }
        public int pergjegjes_id { get; set; }
        public Nullable<System.DateTime> data_Modifikimit { get; set; }
    
        public virtual ADRESA ADRESA { get; set; }
        public virtual PERDORUE PERDORUE { get; set; }
        public virtual PERDORUE PERDORUE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POROSI_ITEM> POROSI_ITEM { get; set; }
    }
}