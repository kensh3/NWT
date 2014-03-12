using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using NWTServisiVjezba.Model;

namespace NWTServisiVjezba.NWTWcfServiceVjezba
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
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

        public string DodajStudenta(Student stud)
        {
            return "\nDodali ste studenta! \nIme: " + stud.Ime + " \nGodiste: " + stud.Godiste + " \nIndex: " + stud.Index;
        }
    }
}
