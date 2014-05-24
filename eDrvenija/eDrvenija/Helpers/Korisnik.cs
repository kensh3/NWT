using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDrvenija.eDrvenija.Helpers
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string EMail { get; set; }
        public string BrojTelefona { get; set; }
        //public byte[] AvatarKorisnika { get; set; }
        public double Ocjena { get; set; }
        //public int KorisnikAktivanOd { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaKorisnika { get; set; }
        //public bool Aktivan { get; set; }
        public int IdTipKorisnika { get; set; }
    }
}