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
        IRepository<Album> albumrepo;
        

        public AlbumLogic(IRepository<Album> repository)
        {
            this.albumrepo = repository;
        }

        public void Create(Album item)
        {
            this.albumrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.albumrepo.Delete(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.albumrepo.ReadAll();
        }

        public Album Read(int id)
        {
            return this.albumrepo.Read(id);
        }

        public void Update(Album item)
        {
            this.albumrepo.Update(item);
        }


    }
}
