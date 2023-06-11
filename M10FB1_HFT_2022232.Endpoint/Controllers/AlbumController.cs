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
    public class AlbumController
    {
        IAlbumLogic logic;

        public AlbumController(IAlbumLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Album album)
        {
            logic.Create(album);
        }

        [HttpPut]
        public void Update([FromBody] Album album)
        {
            logic.Update(album);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
