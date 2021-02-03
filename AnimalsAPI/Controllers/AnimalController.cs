using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private static List<Animal> animals = new List<Animal>();
        private static int count = 0;
        public AnimalController()
        {
            Animal dog = new Animal
            {
                Id = count++,
                Name = "Dog",
                Description = "It barks"
            };
            Animal pig = new Animal
            {
                Id = count++,
                Name = "Pig",
                Description = "It smells"
            };
            animals.Add(dog);
            animals.Add(pig);
        }
        
        
        // GET: api/<AnimalsController>
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return animals;
        }

        // GET api/<AnimalsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(animals.Where(animal => animal.Id == id).FirstOrDefault());
        }

        // POST api/<AnimalsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Animal animal)
        {
            animal.Id = count++;
            animals.Add(animal);
            return CreatedAtAction("Get", new { id = animal.Id }, animal);
        }

        // PUT api/<AnimalsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Animal animal)
        {
            Animal found = animals.Where(n => n.Id == id).FirstOrDefault();
            found.Name = animal.Name;
            found.Description = animal.Description;
            return NoContent();
        }

        // DELETE api/<AnimalsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            animals.RemoveAll(n => n.Id == id);
            return NoContent();
        }
    }
}
