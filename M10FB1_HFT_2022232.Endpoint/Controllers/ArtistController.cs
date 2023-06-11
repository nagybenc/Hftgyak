using M10FB1_HFT_2022232.Logic;
using M10FB1_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M10FB1_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController:ControllerBase
    {
        IArtistLogic logic;

        public ArtistController(IArtistLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Artist> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Artist Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Artist artist)
        {
            logic.Create(artist);
        }

        [HttpPut]
        public void Update([FromBody] Artist artist)
        {
            logic.Update(artist);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
