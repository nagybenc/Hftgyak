using M10FB1_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album item);
        void Delete(int id);
        Album Ream(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
    }
}
