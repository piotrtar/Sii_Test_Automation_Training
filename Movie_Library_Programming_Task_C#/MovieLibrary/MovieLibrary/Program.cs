using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.DAO;
using MovieLibrary.VIEW;
using MovieLibrary.Controller;
using System.IO;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dao Dao = new Dao();
            View View = new View();
            AppController AppController = new AppController(Dao, View);
            Dao.LoadObjectsFromJsonFile();
            AppController.HandleMenu();
        }
    }
}