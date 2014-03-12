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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {

        [OperationContract]
        Student DajStudenta(int id);

        [OperationContract]
        string DodajStudenta(Student stud);
    }
}
