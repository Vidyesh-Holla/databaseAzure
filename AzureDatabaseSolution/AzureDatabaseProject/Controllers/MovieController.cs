using AzureDatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureDatabaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ShowContext _context;

        public MovieController(ShowContext context)
        {
            _context = context;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Movie> menu = _context.Movies.ToList();
                return Ok(menu);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return Ok("success");
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
