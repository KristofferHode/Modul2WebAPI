
using Microsoft.AspNetCore.Mvc;
using VideoGameModel.model;

namespace Modul2WEBAPI.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGameCsvRepository _repo;

        public VideoGamesController(VideoGameCsvRepository repo)
        {
            _repo=repo;
        }
        //READ ALL
        [HttpGet]
        public IActionResult GetAll()
            =>Ok(_repo.GetAll());
        

        //READ BY ID
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var game = _repo.GetById(id);
            return game == null ? NotFound() : Ok(game);
        }

        //CREATE
        [HttpPost]
        public IActionResult Create (VideoGame game)
        {
            var created = _repo.Add(game);
            return CreatedAtAction(nameof(GetById), new {id=created.GameID}, created);
        }
        
        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, VideoGame game)
        {
            var success = _repo.Update(id,game);
            return success? NoContent():NotFound();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            return success ? NoContent():NotFound();
        }
        
    }
}