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
        IRepository<Artist> repository;
        public ArtistLogic(IRepository<Artist> repository)
        {
            this.repository = repository;
        }
        public void Create(Artist item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Artist Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Artist item)
        {
            this.repository.Update(item);
        }
    }
}
