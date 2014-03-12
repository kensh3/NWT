using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NWTServisiVjezba.Model
{
    [Serializable]
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public int Godiste { get; set; }
        [DataMember]
        public int Index { get; set; }

        public Student() { }

        public Student(int id, string ime, int god, int index)
        {
            Id = id;
            Ime = ime;
            Godiste = god;
            Index = index;
        }

        public Student(string ime, int god, int index)
        {
            Ime = ime;
            Godiste = god;
            Index = index;
        }
    }
}
