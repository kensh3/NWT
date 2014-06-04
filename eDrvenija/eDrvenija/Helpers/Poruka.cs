using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDrvenija.eDrvenija.Helpers
{
    public class Poruka
    {
        public int Id { get; set; }
        public string NaslovPoruke { get; set; }
        public string TekstPoruke { get; set; }
        public bool Aktivan { get; set; }
        public int PosiljaocId { get; set; }
        public int PrimaocId { get; set; }

    }
}