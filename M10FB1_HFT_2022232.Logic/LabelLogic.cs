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
        IRepository<Label> repository;

        public LabelLogic(IRepository<Label> repository)
        {
            this.repository = repository;
        }

        public void Create(Label item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Label Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Label> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Label item)
        {
            this.repository.Update(item);
        }
    }
}
