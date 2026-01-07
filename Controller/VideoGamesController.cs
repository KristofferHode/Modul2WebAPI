using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Modul2WEBAPI.Data;
using VideoGame.model;
using

namespace Modul2WEBAPI.Controller;
[ApiController]
[Route("api/[Controller")]
public class VideoGamesController : ControllerBase
{
    private readonly VideoGameRepository _repo;

    public VideoGamesController(VideoGameRepository repo)
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