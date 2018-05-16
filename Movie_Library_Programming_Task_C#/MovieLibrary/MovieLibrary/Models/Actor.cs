using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Actor
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Actor(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
    }
    
}
