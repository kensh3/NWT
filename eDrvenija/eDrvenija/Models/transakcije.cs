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
    using Resursi;
    
    public partial class transakcije
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idTransakcije { get; set; }

        [Display(Name = "DatumTransakcije", ResourceType = typeof(Resursi))]
        [Required(ErrorMessageResourceName = "DatumTransakcijeReq", ErrorMessageResourceType = typeof(Resursi))]
        public Nullable<System.DateTime> datumTransakcije { get; set; }

        [Display(Name = "Korisnik", ResourceType = typeof(Resursi))]
        [Required(ErrorMessageResourceName = "KorisnikReq", ErrorMessageResourceType = typeof(Resursi))]
        [StringLength(45, ErrorMessageResourceName = "KorisnikLen", ErrorMessageResourceType = typeof(Resursi))]
        public int idKorisnika { get; set; }

        [Display(Name = "Oglas", ResourceType = typeof(Resursi))]
        [Required(ErrorMessageResourceName = "OglasReq", ErrorMessageResourceType = typeof(Resursi))]
        [StringLength(45, ErrorMessageResourceName = "OglasLen", ErrorMessageResourceType = typeof(Resursi))]
        public int idOglasa { get; set; }
    
        public virtual korisnici korisnici { get; set; }
        public virtual oglasi oglasi { get; set; }
    }
}
