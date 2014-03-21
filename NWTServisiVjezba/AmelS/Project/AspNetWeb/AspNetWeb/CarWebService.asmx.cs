using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AspNetWeb
{
    /// <summary>
    /// Summary description for CarWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CarWebService : System.Web.Services.WebService
    {
        private nwt1Entities db = new nwt1Entities();

        [WebMethod]
        public List<car> Cars()
        {
            List<car> lista = db.cars.ToList();
            return lista;
        }
    }
}
