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
    
    public partial class korisnicikategorije
    {
        public int idKorisnikaKategorije { get; set; }
        public int idKorisnika { get; set; }
        public int idKategorije { get; set; }
    
        public virtual kategorije kategorije { get; set; }
        public virtual korisnici korisnici { get; set; }
    }
}
