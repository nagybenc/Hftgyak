using M10FB1_HFT_2022232.Models;
using M10FB1_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Logic
{
    public class LabelLogic : ILabelLogic
    {
        IRepository<Label> labelrepo;

        public LabelLogic(IRepository<Label> repository)
        {
            this.labelrepo = repository;
        }

        public void Create(Label item)
        {
            this.labelrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.labelrepo.Delete(id);
        }

        public Label Read(int id)
        {
            return this.labelrepo.Read(id);
        }

        public IQueryable<Label> ReadAll()
        {
            return this.labelrepo.ReadAll();
        }

        public void Update(Label item)
        {
            this.labelrepo.Update(item);
        }


    }
}
