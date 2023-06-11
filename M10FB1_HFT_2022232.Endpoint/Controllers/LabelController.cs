using M10FB1_HFT_2022232.Logic;
using M10FB1_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LabelController:ControllerBase
    {
        ILabelLogic logic;

        public LabelController(ILabelLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Label> ReadAll()
        { return logic.ReadAll(); }

        [HttpGet("{id}")]
        public Label Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Label label)
        {
            logic.Create(label);
            //this.hub.Clients.All.SendAsync("LabelCreated", label);
        }

        [HttpPut]
        public void Update([FromBody] Label label)
        {
            logic.Update(label);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
