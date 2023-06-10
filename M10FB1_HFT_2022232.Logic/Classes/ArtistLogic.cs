using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> artistrepo;
        public ArtistLogic(IRepository<Artist> repository)
        {
            this.artistrepo = repository;
        }
        public void Create(Artist item)
        {
            this.artistrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.artistrepo.Delete(id);
        }

        public Artist Read(int id)
        {
            return this.artistrepo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.artistrepo.ReadAll();
        }

        public void Update(Artist item)
        {
            this.artistrepo.Update(item);
        }


    }
}
