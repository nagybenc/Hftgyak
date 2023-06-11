using System;
using System.Linq;
using ConsoleTools;
using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;

namespace M10FB1_HFT_2022232.Client
{
    class Program
    {
        public static RestService rest = new RestService("http://localhost:24308");
        static void Main(string[] args)
        {
            MusicDbContext db = new MusicDbContext();
            //var albums = db.Albums.ToArray();

            var menu = new ConsoleMenu()
              .Add("CRUD methods", () => CrudMenu())
              //.Add("non-CRUD methods", () => NonCrudMenu())
              .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CrudMenu()
        {

            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                //.Add("Get one element", ReadPreMenu)
                //.Add("Get all element", ReadAllPreMenu)
                //.Add("Update element", UpdatePreMenu)
                //.Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PreMenu(Action Label, Action Album, Action Artist)
        {
            var menu = new ConsoleMenu()
                .Add("Label", Label)
                .Add("Album", Album)
                .Add("Artist", Artist)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CreatePreMenu()
        {
            PreMenu(CreateLabel, CreateAlbum, CreateArtist);
        }

        private static void CreateArtist()
        {
            Console.WriteLine("ArtistName: ");
            string artistname = Console.ReadLine();
            Console.WriteLine("Country:");
            string artistcountry = Console.ReadLine();
            Console.WriteLine("AlbumId:");
            int artistalbum = int.Parse(Console.ReadLine());

            rest.Post<Artist>(new Artist() { Name = artistname, Country = artistcountry, AlbumId=artistalbum  }, "Artist");
        }

        private static void CreateAlbum()
        {
            Console.WriteLine("TeamName: ");
            string carname = Console.ReadLine();
            Console.WriteLine("Wins:");
            string cartype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            //rest.Post<Car>(new Car() { CarName = carname, CarType = cartype, Brand_id = brandid }, "Car");
        }

        private static void CreateLabel()
        {
            Console.WriteLine("Name: ");
            string buyername = Console.ReadLine();
            Console.WriteLine("Role name:");
            string buyergender = Console.ReadLine();
            Console.WriteLine("Car id: ");
            int Carid = int.Parse(Console.ReadLine());
            //rest.Post<RentCar>(new RentCar() { BuyerName = buyername, BuyerGender = buyergender, Car_id = Carid }, "RentCar");
        }
    }
}
