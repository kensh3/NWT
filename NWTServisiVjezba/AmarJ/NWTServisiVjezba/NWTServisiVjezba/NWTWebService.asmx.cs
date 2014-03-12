using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using NWTServisiVjezba.Model;

namespace NWTServisiVjezba.NWTServisiVjezba
{
    /// <summary>
    /// Summary description for NWTWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NWTWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Ime(string Ime)
        {
            return "Vase ime je: " + Ime;
        }

        [WebMethod]
        public string Zbir(int x, int y)
        {
            return "Zbir je: " + Convert.ToString(x + y);
        }

        [WebMethod]
        public Student DajStudenta(int id)
        {
            switch (id)
            {
                case 0:
                    return new Student("Amar", 1992, 15885);
                case 1:
                    return new Student("Amel S.", 1990, 12345);
                case 2:
                    return new Student("Amel D.", 1992, 32412);
                case 3:
                    return new Student("Kenan", 1992, 12432);
                default:
                    return new Student("Student", 2014, 99999);
            }
        }

        [WebMethod]
        public string DodajStudenta(Student stud)
        {
            return "\nDodali ste studenta! \nIme: " + stud.Ime + " \nGodiste: " + stud.Godiste + " \nIndex: " + stud.Index;
        }
    }
}
