using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLHDemosAPIs.Models
{
    public class People
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public People()
        { }

        public People(int Id, string Name, int Age)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
        }
    }
}
