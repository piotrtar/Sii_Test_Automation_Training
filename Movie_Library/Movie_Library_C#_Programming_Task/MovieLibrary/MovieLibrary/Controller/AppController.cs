using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.DAO;
using MovieLibrary.Models;
using MovieLibrary.VIEW;

namespace MovieLibrary.Controller
{
    class AppController
    {
        public Dao Dao;
        public View View;
        public List<Movie> MoviesByActor;
        public List<Movie> MoviesByGenre;
        public List<Movie> MoviesByTimeFrame;

        public AppController(Dao Dao, View View)
        {
            this.Dao = Dao;
            this.View = View;
        }

        public void HandleMenu()
        {
            string UserChoice = "";

            while (!UserChoice.Equals("0"))
            {
                View.ShowMenu();
                try
                {
                    UserChoice = View.GetChoice();
                    switch (UserChoice)
                    {
                        case "1":
                            View.DisplayMovies(GetMoviesByActor());
                            break;

                        case "2":
                            View.DisplayMovies(GetMoviesByGenre());
                            break;

                        case "3":
                            View.DisplayMovies(GetMoviesByTimeFrame());
                            break;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public List<Movie> GetMoviesByActor()
        {
            MoviesByActor = new List<Movie>();
            View.PrintProvideActorMsg();
            string ActorName = View.GetActor();
            foreach (Movie FilteredMovie in Dao.GetMovies)
            {
                foreach (Actor FilteredActor in FilteredMovie.Actors)
                {
                    if (FilteredActor.ToString().ToLower().Contains(ActorName.ToLower()))
                    {
                        MoviesByActor.Add(FilteredMovie);
                    }
                }
            }
            if (MoviesByActor.Count() == 0)
            {
                View.PrintNotFoundMsg();
            }
            return MoviesByActor;
        }

        public List<Movie> GetMoviesByGenre()
        {
            MoviesByGenre = new List<Movie>();
            View.PrintProvideGenreMsg();
            string Genre = View.GetGenre();
            foreach (Movie FilteredMovie in Dao.GetMovies)
            {
                if (!FilteredMovie.Genre.Equals(null))
                {
                    if (FilteredMovie.Genre.ToLower().Contains(Genre.ToLower()))
                    {
                        MoviesByGenre.Add(FilteredMovie);
                    }
                }
            }
            if (MoviesByGenre.Count() == 0)
            {
                View.PrintNotFoundMsg();
            }
            return MoviesByGenre;
        }

        public List<Movie> GetMoviesByTimeFrame()
        {
            MoviesByTimeFrame = new List<Movie>();
            View.PrintProvideStartYearMsg();
            int FromYear = View.GetFromYear();
            View.PrintProvideEndYearMsg();
            int ToYear = View.GetToYear();
            foreach (Movie FilteredMovie in Dao.GetMovies)
            {
                if (FilteredMovie != null)
                {
                    if (FilteredMovie.Year >= FromYear && FilteredMovie.Year <= ToYear)
                    {
                        MoviesByTimeFrame.Add(FilteredMovie);
                    }
                }
            }

            if (MoviesByTimeFrame.Count() == 0)
            {
                View.PrintNotFoundMsg();
            }
            return MoviesByTimeFrame;
        }
    }
}
