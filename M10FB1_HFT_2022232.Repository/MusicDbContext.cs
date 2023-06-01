﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True; MultipleResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // creating test objects
            Label loud = new() {Id=1,Name="Loud Records", Address="New York City", Albums=null };
            Label warner = new() { Id = 2, Name = "Warner Bros Records", Address = "Los Angeles", Albums = null };
            Label shady = new() { Id = 3, Name = "Shady Records", Address = "Detroit", Albums = null };
            Label bpc = new() { Id = 4, Name = "BPitch Control", Address = "Berlin", Albums = null };
            Label columbia = new() { Id = 5, Name = "Columbia", Address = "Washington DC", Albums = null };

            Album enterwu  = new() { Id = 1, Name = "Enter The Wu-Tang", Genre="Rap", LabelId=loud.Id,Artists=null };
            Album better = new() { Id = 2, Name = "A Beter Tomorrow", Genre = "Rap", LabelId = warner.Id, Artists = null };

            Artist rza = new() {Id=1, Name="RZA", Country="USA", AlbumId=enterwu.Id };
            Artist gza = new() { Id = 2, Name = "GZA", Country = "USA", AlbumId =better.Id };


            // connections

             modelBuilder.Entity<Album>(entity =>
             {
                 entity.HasOne(label => label.Label)
                     .WithMany(label => label.Albums)
                     .HasForeignKey(album => album.LabelId)
                     .OnDelete(DeleteBehavior.SetNull);
             });

            /*modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasOne(album=>album.Label)
                .WithMany(artist=>artist.Artists);
            });*/


            modelBuilder.Entity<Label>().HasData(loud,warner,shady,bpc,columbia);
            modelBuilder.Entity<Album>().HasData(enterwu,better);
            modelBuilder.Entity<Artist>().HasData(rza,gza);


            base.OnModelCreating(modelBuilder);
        }
    }
}
