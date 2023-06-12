using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M10FB1_HFT_2022232.Models;

namespace M10FB1_HFT_2022232.Repository
{
    public class MusicDbContext:DbContext
    {
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }

        public MusicDbContext()
        {
            Database.EnsureCreated();
        }

        /*public MusicDbContext(DbContextOptions<MusicDbContext> options):base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Music.mdf;Integrated Security=True; MultipleActiveResultSets=True;");
                //base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseInMemoryDatabase("Music");
            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // creating test objects
            Label loud = new() {Id=1,Name="Loud Records", Address="New York City" };
            Label warner = new() { Id = 2, Name = "Warner Bros Records", Address = "Los Angeles"};
            Label shady = new() { Id = 3, Name = "Shady Records", Address = "Detroit"};
            Label bpc = new() { Id = 4, Name = "BPitch Control", Address = "Berlin"};
            Label columbia = new() { Id = 5, Name = "Columbia", Address = "Washington DC"};

            Album enterwu  = new() { Id = 1, Name = "Enter The Wu-Tang", Genre="Rap", LabelId=loud.Id, ReleaseDate=DateTime.Parse("1993,11,09")  };
            Album better = new() { Id = 2, Name = "A Better Tomorrow", Genre = "Rap", LabelId = warner.Id , ReleaseDate=DateTime.Parse("2014.12.02")};

            Artist rza = new() {Id=1, Name="RZA", Country="USA", AlbumId=enterwu.Id };
            Artist gza = new() { Id = 2, Name = "GZA", Country = "USA", AlbumId =better.Id };


            // connections

             modelBuilder.Entity<Album>(entity =>
             {
                 entity.HasOne(label => label.Label)
                     .WithMany(label => label.Albums)
                     .HasForeignKey(album => album.LabelId)
                     .OnDelete(DeleteBehavior.Cascade);
             });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasOne(album=>album.Album)
                .WithMany(artist=>artist.Artists)
                .HasForeignKey(album=>album.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
            });



            //adding the objects to the correct tables
            modelBuilder.Entity<Label>().HasData(loud,warner,shady,bpc,columbia);
            modelBuilder.Entity<Album>().HasData(enterwu,better);
            modelBuilder.Entity<Artist>().HasData(rza,gza);


           // base.OnModelCreating(modelBuilder);
        }
    }
}
