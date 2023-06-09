using M10FB1_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Repository
{
    class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(MusicDbContext mdb) : base(mdb)
        { }

        public override Artist Read(int id)
        {
            return mdb.Artists.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Artist item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old,prop.GetValue(item));
            }
            mdb.SaveChanges();
        }
    }
}
