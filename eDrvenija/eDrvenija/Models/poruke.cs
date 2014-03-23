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
    using System.ComponentModel;
    
    public partial class poruke
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idPoruke { get; set; }

        [DisplayName("Naslov poruke")]
        [Required(ErrorMessage="Potrebno je unijeti naslov poruke i ne smije biti du�i od 45 znakova")]
        [MaxLength(45, ErrorMessage="Maksimalna du�ina je 45 znakova")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string naslovPoruke { get; set; }

        [DisplayName("Tekst poruke")]
        [Required(ErrorMessage = "Potrebno je unijeti tekst poruke i ne smije biti du�i od 1000 znakova")]
        [MaxLength(1000, ErrorMessage = "Maksimalna du�ina je 1000 znakova")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string tekstPoruke { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<bool> aktivan { get; set; }

        [ScaffoldColumn(false)]
        public int idKorisnikaPosiljaoca { get; set; }

        [ScaffoldColumn(false)]
        public int idKorisnikaPrimaoca { get; set; }
    
        public virtual korisnici korisnici { get; set; }
        public virtual korisnici korisnici1 { get; set; }
    }
}
