//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDrvenija.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipovioglasa
    {
        public tipovioglasa()
        {
            this.oglasi = new HashSet<oglasi>();
        }
    
        public int idTipaOglasa { get; set; }
        public string nazivTipaOglasa { get; set; }
    
        public virtual ICollection<oglasi> oglasi { get; set; }
    }
}
