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
    
    public partial class tipovikorisnika
    {
        public tipovikorisnika()
        {
            this.korisnici = new HashSet<korisnici>();
        }
    
        public int idTipaKorisnika { get; set; }
        public string nazivTipaKorisnika { get; set; }
    
        public virtual ICollection<korisnici> korisnici { get; set; }
    }
}
