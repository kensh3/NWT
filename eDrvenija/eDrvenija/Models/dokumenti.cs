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
    using Resursi;
    
    public partial class dokumenti
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idDokumenta { get; set; }

        [Display(Name = "Dokument", ResourceType = typeof(Resursi))]
        [Required(ErrorMessageResourceName = "DokumentReq", ErrorMessageResourceType = typeof(Resursi))]
        public byte[] dokument { get; set; }

        [Display(Name = "BrojPreuzimanja", ResourceType = typeof(Resursi))]
        [ReadOnly(true)]
        public Nullable<int> brojPreuzimanja { get; set; }

        [Display(Name = "Oglas", ResourceType = typeof(Resursi))]
        [Required(ErrorMessageResourceName = "OglasReq", ErrorMessageResourceType = typeof(Resursi))]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int idOglasa { get; set; }
    
        public virtual oglasi oglasi { get; set; }
    }
}
