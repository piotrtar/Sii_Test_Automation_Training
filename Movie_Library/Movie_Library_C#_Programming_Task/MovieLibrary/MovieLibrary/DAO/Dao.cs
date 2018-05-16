using MovieLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.DAO
{
    public class Dao
    {
        private const char delimiter = ',';
        private IList<Movie> Movies;

        public IList<Movie> GetMovies { get => Movies; set => Movies = value; }

        public Dao()
        {
            this.Movies = null;
        }

        public void LoadObjectsFromJsonFile()
        {
            string SolutionPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            Console.WriteLine(SolutionPath);
            string Filepath = SolutionPath + "\\Resources\\movies-filtered.json";
            Console.WriteLine(Filepath);
            using (StreamReader Sr = new StreamReader(Filepath))
            {
                var Json = Sr.ReadToEnd();
                Movies = JsonConvert.DeserializeObject<List<Movie>>(Json);
            }
            LoadActors();
        }

        public void LoadActors()
        {
            foreach ( Movie movie in Movies)
            {
                if ( movie.Cast != null)
                {
                    if ( movie.Cast.Contains(","))
                    {
                        string[] Actors = movie.Cast.Split(delimiter);
                        foreach ( string ActorString in Actors)
                        {
                            Actor Actor = ParseToActor(ActorString);
                            movie.Actors.Add(Actor);
                        }
                    } else
                    {
                        Actor SingleActor = ParseToActor(movie.Cast);
                        movie.Actors.Add(SingleActor);
                    }

                }
            }
        }

        private static Actor ParseToActor(String ActorString)
        {
            string Name = null;
            string Surname = null;

            try
            {
                string[] NameSurname = ActorString.Trim().Split(' ');
                Name = NameSurname[0];
                Surname = NameSurname[1];
            } catch (IndexOutOfRangeException)
            {
            }
            Actor Actor = new Actor(Name, Surname);
            return Actor;
        }
    }
}
