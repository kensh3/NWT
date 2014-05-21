using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resursi;

namespace eDrvenija.eDrvenija.Helpers
{
    public class Oglas
    {

        public int idOglasa { get; set; }
        public string nazivOglasa { get; set; }
        public Nullable<System.DateTime> datumObjaveOglasa { get; set; }
        public string opisOglasa { get; set; }
        public Nullable<double> cijena { get; set; }
        public Nullable<int> brojPregledaOglasa { get; set; }
        public Nullable<bool> zavrsenaTransakcija { get; set; }
        public Nullable<bool> aktivan { get; set; }
        public int idTipaOglasa { get; set; }
        public int idKategorije { get; set; }
        public int idKorisnika { get; set; }

    }
}