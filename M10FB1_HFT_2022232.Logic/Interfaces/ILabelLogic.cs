using M10FB1_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Logic
{
    public interface ILabelLogic
    {
        //CRUD
        void Create(Label item);
        void Delete(int id);
        Label Read(int id);
        IQueryable<Label> ReadAll();
        void Update(Label item);

        //NON-CRUD

    }
}
