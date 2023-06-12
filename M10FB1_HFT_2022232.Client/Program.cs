using System;
using System.Collections.Generic;
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
                .Add("Get one element", ReadPreMenu)
                .Add("Get all element", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
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

            rest.Post<Artist>(new Artist() { Name = artistname, Country = artistcountry, AlbumId = artistalbum }, "Artist");
        }

        private static void CreateAlbum()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();
            Console.WriteLine("Release:");
            DateTime release = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Label id: ");
            int labelid = int.Parse(Console.ReadLine());
            rest.Post<Album>(new Album() { Name = name, Genre = genre, ReleaseDate=release,LabelId = labelid}, "Album");
        }

        private static void CreateLabel()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();
            rest.Post<Label>(new Label() { Name = name, Address =address  }, "Label");
        }

        private static void ReadPreMenu()
        {
            PreMenu(ReadLabel, ReadAlbum, ReadArtist);
        }

        private static void ReadArtist()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getArtist = rest.Get<Artist>(id, "Artist");
            Console.WriteLine($"Id: {getArtist.Id}, ArtistName: {getArtist.Name}, Country: {getArtist.Country}," +
                $" AlbumId:{getArtist.AlbumId}, Album:{getArtist.Album}");
            Console.ReadLine();

        }

        private static void ReadAlbum()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getAlbum = rest.Get<Album>(id, "Album");
            Console.WriteLine($"Id: {getAlbum.Id}, Name: {getAlbum.Name}, ReleaseDate: {getAlbum.ReleaseDate}, LabelId: {getAlbum.LabelId}");
            Console.ReadLine();
        }

        private static void ReadLabel()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getLabel = rest.Get<Label>(id, "Label");
            Console.WriteLine($"Id: {getLabel.Id}, Name: {getLabel.Name}, Address: {getLabel.Address}");
            Console.ReadLine();
        }

        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllLabel, PrintAllAlbum, PrintAllArtist);
        }

        private static void PrintAllLabel()
        {
            var labels = rest.Get<Label>("Label");
            Console.WriteLine("-------------Labels-------------");
            LabelToConsole(labels);
            Console.ReadLine();
        }
        private static void PrintAllAlbum()
        {
            List<Album>  albums= rest.Get<Album>("Album");
            Console.WriteLine("-------------Albums-------------");
            //AlbumToConsole(albums);
            foreach (var album in albums)
            {
                Console.WriteLine(album.ToString());   
            }
            Console.ReadLine();
        }
        private static void PrintAllArtist()
        {
            var artists = rest.Get<Artist>("Artist");
            Console.WriteLine("-------------Artists-------------");
            ArtistToConsole(artists);
            Console.ReadLine();
        }

        //Update

        private static void UpdatePreMenu()
        {
            PreMenu(UpdateLabel, UpdateAlbum, UpdateArtist);
        }

        private static void UpdateArtist()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Country:");
            string country = Console.ReadLine();
            Console.WriteLine("AlbumId:");
            int albumid = int.Parse(Console.ReadLine());
            Artist input = new Artist() { Id = id, Name = name, Country = country, AlbumId=albumid };
            rest.Put(input, "Artist");
        }

        private static void UpdateAlbum()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();
            Console.WriteLine("Release:");
            DateTime release = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Label id: ");
            int labelid = int.Parse(Console.ReadLine());
            Album input = new Album() { Id = id, Name = name,  Genre=genre, ReleaseDate=release, LabelId= labelid };
            rest.Put(input, "Album");
        }

        private static void UpdateLabel()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address:");
            string address = Console.ReadLine();
            Label input = new Label() { Id = id, Name = name, Address = address,   };
            rest.Put(input, "Label");
        }

        //Delete
        private static void DeletePreMenu()
        {
            PreMenu(DeleteLabel, DeleteAlbum, DeleteArtist);
        }

        private static void DeleteArtist()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "Artist");
        }

        private static void DeleteAlbum()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "Album");
        }

        private static void DeleteLabel()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "Label");
        }






        //ToConsole
        private static void LabelToConsole(IEnumerable<Label> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Address: {item.Address}");
            }
        }
        private static void AlbumToConsole(IEnumerable<Album> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, ReleaseDate:{item.ReleaseDate}, LabelId:{item.LabelId}");
            }
        }
        private static void ArtistToConsole(IEnumerable<Artist> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Country:{item.Country}, AlbumId:{item.AlbumId}");
            }
        }
    }
}
