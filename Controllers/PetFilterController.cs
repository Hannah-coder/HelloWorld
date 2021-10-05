﻿using API.Models;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PetFilterController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public PetFilterController(ILogger<PetFilterController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets the pets.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PetFilter> GetPets()
        {
            var pets = _context.PetFilter.ToList();

            return pets;
        }

        /// <summary>
        /// Gets the pet.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("single/{id}")]
        public ActionResult<PetFilter> GetPet(int id)
        {
            var pet = _context.PetFilter.Single(x => x.Id == id);

            if (pet == null)
                return NotFound();

            return pet;
        }

        /// <summary>
        /// Gets a list of pets based on category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        [HttpGet("ByCategory/{category}")]
        public IEnumerable<PetFilter> GetCategory(string category)
        {
            var pets = _context.PetFilter.ToList().Where(x => x.Category == category);

            return pets;
        }

        /// <summary>
        /// Adds the pet.
        /// </summary>
        /// <param name="pet">The pet.</param>
        /// <returns></returns>
        [HttpPost]
        public PetFilter AddPet(PetFilter pet)
        {
            _context.PetFilter.Add(pet);
            _context.SaveChangesAsync();

            return pet;
        }

        /// <summary>
        /// Deletes the pet.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the pets by month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        [HttpGet("ByMonth/{month}")]
        public IEnumerable<PetFilter> GetPetsByMonth(int month)
        {
            var pets = _context.PetFilter.ToList().Where(x => x.Time.Month == month);
            
            return pets;
        }
    }
}