using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDrvenija.eDrvenija.Helpers
{
    public class Komentar
    {
        public int Id { get; set; }
        public string TekstKomentara { get; set; }
        public bool Aktivan { get; set; }
        public int IdKorisnika { get; set; }
        public int IdOglasa { get; set; }
    }
}