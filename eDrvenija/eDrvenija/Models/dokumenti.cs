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
    
    public partial class dokumenti
    {
        [Key]
        public int idDokumenta { get; set; }
        public string nazivDokumenta { get; set; }
        public string opisDokumenta { get; set; }
        public Nullable<System.DateTime> datumObjaveDokumenta { get; set; }
        public Nullable<int> brojPreuzimanjaDokumenta { get; set; }
        public byte[] dokument { get; set; }
    
        public virtual oglasi oglasi { get; set; }
    }
}
