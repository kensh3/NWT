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
    using System.ComponentModel.DataAnnotations;
    
    public partial class upiti
    {
        [Key]
        public int idUpita { get; set; }
        public string naslovUpita { get; set; }
        public string tekstUpita { get; set; }
        public int idKorisnika { get; set; }
    
        public virtual korisnici korisnici { get; set; }
    }
}
