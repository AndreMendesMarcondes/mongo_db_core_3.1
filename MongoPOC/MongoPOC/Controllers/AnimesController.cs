using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoPOC.Models;
using MongoPOC.Services;

namespace MongoPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimesController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_animeService.Get());

        [HttpGet("{id:length(24)}", Name = "GetAnime")]
        public IActionResult Get(string id)
        {
            var anime = _animeService.Get(id);

            if (anime == null)
                return NotFound();

            return Ok(anime);
        }

        [HttpPost]
        public IActionResult Create(Anime anime)
        {
            _animeService.Create(anime);

            return StatusCode(201);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Anime animeIn)
        {
            var anime = _animeService.Get(id);

            if (anime == null)
                return NotFound();

            _animeService.Update(id, animeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var anime = _animeService.Get(id);

            if (anime == null)
                return NotFound();

            _animeService.Remove(anime.Id);

            return NoContent();
        }
    }
}