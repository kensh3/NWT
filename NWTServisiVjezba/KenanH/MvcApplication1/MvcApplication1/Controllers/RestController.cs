using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class RestController : ApiController
    {

        // GET api/rest
        public IEnumerable<string> Get()
        {
            return new string[] { "Bezvezna metoda", "ne primam nista, vracam gluposti", "bla", "bla" };
        }

        // GET api/rest/zbir
        public int Get(int a,int b)
        {
             return a + b;
        }

        // GET api/rest/5
        public string Get(int id)
        {
            if (id == 1) return "Vraćam prvog studenta.";
            if (id == 2) return "Vraćam drugog studenta.";
            else return "Ne znam ni ja šta vraćam.";
        }

        // POST api/rest
        public string Post([FromBody]string value)
        {

            return "Unijeli ste: " +  value;
        }



    }
}
