using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.VIEW
{
    public class View
    {
        public View()
        {
        }

        public void ShowMenu()
        {
            string Menu = "Welcome in Movie Library! \r\n" +
                            "Choose option: \r\n" +
                            "1) Find films by actor. \r\n" +
                            "2) Find films by genre. \r\n" +
                            "3) Find films between given years. \r\n" +
                            "0) Exit. \r\n";

            Console.WriteLine(Menu);
        }

        public void DisplayMovies(List<Movie> Movies)
        {
            foreach ( Movie Movie in Movies)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(Movie);
                Console.WriteLine("----------------------");
            }
        }

        public string GetChoice()
        {
            return Console.ReadLine();
        }

        public string GetActor()
        {
            return Console.ReadLine();
        }

        public string GetGenre()
        {
            return Console.ReadLine();
        }

        public int GetFromYear()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetToYear()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public void PrintProvideActorMsg()
        {
            Console.WriteLine("Provide actor name and surname: ");
        }

        public void PrintProvideGenreMsg()
        {
            Console.WriteLine("Provide actor name and surname: ");
        }

        public void PrintProvideStartYearMsg()
        {
            Console.WriteLine("Provide actor name and surname: ");
        }

        public void PrintProvideEndYearMsg()
        {
            Console.WriteLine("Provide actor name and surname: ");
        }

        public void PrintNotFoundMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n No data matching given criteria.\r\n \r\n");
            Console.ResetColor();
        }
    }
}
