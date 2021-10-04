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

        public MerchandiseFilterController(ILogger<MerchandiseFilterController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MerchandiseFilter> GetMerchandise()
        {
            var merchandise = _context.MerchandiseFilter.ToList();

            return merchandise;
        }

        [HttpGet("{id}")]
        public ActionResult<MerchandiseFilter> GetItem(int id)
        {
            var item = _context.MerchandiseFilter.Single(x => x.Id == id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpGet("ByCategory/{category}")]
        public IEnumerable<MerchandiseFilter> GetCategory(string category)
        {
            var merchandise = _context.MerchandiseFilter.ToList().Where(x => x.Category == category);

            return merchandise;
        }

        [HttpPost]
        public MerchandiseFilter AddItem(MerchandiseFilter item)
        {
            _context.MerchandiseFilter.Add(item);
            _context.SaveChangesAsync();

            return item;
        }

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

        [HttpGet("ByMonth/{month}")]
        public IEnumerable<MerchandiseFilter> GetMerchandiseByMonth(int month) 
        {
            var merchandise = _context.MerchandiseFilter.ToList().Where(x => x.Time.Month == month);

            return merchandise;
        }
    }
}
