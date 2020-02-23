using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiCore2.Data;
using WepApiCore2.Models;

namespace WepApiCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiCore2Controller<TEntity,TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public WebApiCore2Controller(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await _repository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }            
            await _repository.Update(movie);            
            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> Post(TEntity movie)
        {
            _repository.Add(movie);
            return CreatedAtAction("Get", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> DeleteMovie(int id)
        {
            var movie = await _repository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }           

            return movie;
        }        
    }
}
