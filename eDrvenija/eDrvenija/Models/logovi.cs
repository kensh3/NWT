//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDrvenija.eDrvenija.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class logovi
    {
        public int idLoga { get; set; }
        public string akcijaLoga { get; set; }
        public Nullable<System.DateTime> vrijemeLoga { get; set; }
        public int idKorisnika { get; set; }
    
        public virtual korisnici korisnici { get; set; }
    }
}