using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetFilterController : ControllerBase
    {
        private readonly ILogger<PetFilterController> _logger;
        private readonly MetricsDbContext _context;

        public PetFilterController(ILogger<PetFilterController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PetFilter> GetPets()
        {
            var pets = _context.PetFilter.ToList();

            return pets;
        }
        
        [HttpGet("{id}")]
        public ActionResult<PetFilter> GetPet(int id)
        {
            var pet = _context.PetFilter.Single(x => x.Id == id);

            if (pet == null)
                return NotFound();

            return pet;
        }

        [HttpGet("{category}")]
        public IEnumerable<PetFilter> GetCategory(string category)
        {
            var pets = _context.PetFilter.ToList().Where(x => x.Category == category);

            return pets;
        }

        [HttpPost]
        public PetFilter AddPet(PetFilter pet)
        {
            _context.PetFilter.Add(pet);
            _context.SaveChangesAsync();

            return pet;
        }

        [HttpDelete("{id}")]
        public ActionResult<PetFilter> DeletePet(int id)
        {
            var pet = _context.PetFilter.Single(x => x.Id == id);

            if (pet == null)
                return NotFound();

            _context.PetFilter.Remove(pet);
            _context.SaveChangesAsync();

            return pet;
            //return CreatedAtAction(nameof(_context.Page.Remove), new { id = page.Id });
        }

        [HttpGet("{month}")]
        public IEnumerable<PetFilter> GetPetsByMonth(int month)
        {
            var pets = _context.PetFilter.ToList().Where(x => x.Time.Month == month);

            return pets;
        }
    }
}
