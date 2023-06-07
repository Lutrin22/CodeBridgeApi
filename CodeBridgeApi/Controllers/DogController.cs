using CodeBridgeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace CodeBridgeApi.Controllers
{
    //I set up Request rate limit for 10 requests per 10 seconds
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogDbContext _context;
        private readonly SieveProcessor _sieve;

        public DogController(DogDbContext context, SieveProcessor sieveProcessor)
        {
            _context = context;
            _sieve = sieveProcessor;
        }
        
        //Simple endpoint to receive string in response
        [HttpGet("ping")]
        public string GetPing() 
        {
            var response = "Dogs house service. Version 1.0.1";
            return response;
        }

        //Endpoint for receiving all dogs that we have in database
        [HttpGet("dogs")]
        public async Task<ActionResult> GetAllDogs([FromQuery] SieveModel sieveModel) 
        {
            var dogs =  _context.Dogs.AsQueryable();
            //created that rule for Unit test
            if (_sieve != null)
            {
                dogs = _sieve.Apply(sieveModel, dogs);
            }
            return Ok(dogs);
        }
      
        //Enpoint for creating new dog and add it to database
        [HttpPost("dog")]
        public async Task<ActionResult<Dog>> CreateDogAsync(DogCreateModel model) 
        {
            var dog = new Dog
            {
                Name = model.Name,
                Color = model.Color,
                Tail_Length = model.Tail_Length,
                Weight = model.Weight,
            };

           
            var existingDog = await _context.Dogs.FirstOrDefaultAsync(d => d.Name == model.Name);
            if (existingDog != null)
            {
                return Conflict("A dog with the same name already exists.");
            }

            _ = await _context.Dogs.AddAsync(dog);
            _ = await _context.SaveChangesAsync();

            return dog;
        }
    }
}
