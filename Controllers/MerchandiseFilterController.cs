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
    public class MerchandiseFilterController : ControllerBase
    {
        private readonly ILogger<MerchandiseFilterController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchandiseFilterController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public MerchandiseFilterController(ILogger<MerchandiseFilterController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets a list of merchandise searched.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<MerchandiseFilter> GetMerchandise()
        {
            var merchandise = _context.MerchandiseFilter.ToList();

            return merchandise;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<MerchandiseFilter> GetItem(int id)
        {
            var item = _context.MerchandiseFilter.Single(x => x.Id == id);

            if (item == null)
                return NotFound();

            return item;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        [HttpGet("ByCategory/{category}")]
        public IEnumerable<MerchandiseFilter> GetCategory(string category)
        {
            var merchandise = _context.MerchandiseFilter.ToList().Where(x => x.Category == category);

            return merchandise;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MerchandiseFilter> AddItem(MerchandiseFilter item)
        {
            _context.MerchandiseFilter.Add(item);
            _context.SaveChangesAsync();

            if (item.Id == 0)
                return NotFound();
            
            return item;
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<MerchandiseFilter> DeleteItem(int id)
        {
            var item = _context.MerchandiseFilter.Single(x => x.Id == id);

            if (item == null)
                return NotFound();

            _context.MerchandiseFilter.Remove(item);
            _context.SaveChangesAsync();

            return item;
            //return CreatedAtAction(nameof(_context.Page.Remove), new { id = page.Id });
        }

        /// <summary>
        /// Gets the merchandise by month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        [HttpGet("ByMonth/{month}")]
        public IEnumerable<MerchandiseFilter> GetMerchandiseByMonth(int month) 
        {
            var merchandise = _context.MerchandiseFilter.ToList().Where(x => x.DateAndTime.Month == month);

            return merchandise;
        }
    }
}
