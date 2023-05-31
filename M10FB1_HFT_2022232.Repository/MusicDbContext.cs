using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M10FB1_HFT_2022232.Models;

namespace M10FB1_HFT_2022232.Repository
{
    class MusicDbContext:DbContext
    {
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }

        public MusicDbContext()
        {
            Database.EnsureCreated();
        }


    }
}
