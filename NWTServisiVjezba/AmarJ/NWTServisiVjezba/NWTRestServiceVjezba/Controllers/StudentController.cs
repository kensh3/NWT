using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NWTServisiVjezba.Model;

namespace NWTRestServiceVjezba.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/student
        public IEnumerable<Student> Get()
        {
            return new Student[] { new Student("Amar", 1992, 15885), new Student("Amel S.", 1990, 12345), new Student("Amel D.", 1992, 32412), new Student("Kenan", 1992, 12432) };
        }

        // GET api/student/5
        public Student Get(int id)
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

        // POST api/student
        public string Post([FromBody]Student stud)
        {
            return "\nDodali ste studenta! \nIme: " + stud.Ime + " \nGodiste: " + stud.Godiste + " \nIndex: " + stud.Index;
        }
    }
}
