using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }

        private IList<Actor> _actors ;

        public IList<Actor> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }

        public Movie()
        {
            _actors = new List<Actor>();
        }

        public override string ToString()
        {
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Title: " + this.Title + "\r\n");
            Sb.Append("Year: " + this.Year + "\r\n");
            Sb.Append("Director: " + this.Director + "\r\n");
            Sb.Append("Genre: " + this.Genre + "\r\n");
            Sb.Append("Actors: " + "\r\n");
            foreach (Actor actor in Actors)
            {
                Sb.Append("- " + actor.ToString() + "\r\n");
            }

            return Sb.ToString();
        }
    }
   
}



//var andrzejActors = Actors.Where(a => a.Name == "Andrzej").ToList();
//var idActor = Actors.FirstOrDefault(a => a.Id == 1);

