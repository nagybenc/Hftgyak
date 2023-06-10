using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IRepository<Album> repository;
        public AlbumLogic(IRepository<Album> repository)
        {
            this.repository = repository;
        }

        public void Create(Album item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public Album Ream(int id)
        {
            return this.repository.Read(id);
        }

        public void Update(Album item)
        {
            this.repository.Update(item);
        }
    }
}
