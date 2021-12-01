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
    public class PageViewController : ControllerBase
    {
        private readonly ILogger<PageViewController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public PageViewController(ILogger<PageViewController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<PageViewController>
        [HttpGet]
        public IEnumerable<PageView> GetPageViews()
        {
            var pageViews = _context.PageView.ToList();

            return pageViews;
        }

        // GET api/<PageViewController>/5
        [HttpGet("{id}")]
        public ActionResult<PageView> GetPageView(int id)
        {
            var pageView = _context.PageView.Where(x => x.Id == id).SingleOrDefault();

            if (pageView == null)
                return NotFound();

            return pageView;
        }

        // POST api/<PageViewController>
        [HttpPost]
        public ActionResult<PageView> CreatePageView(PageView pageView)
        {
            _context.PageView.Add(pageView);
            _context.SaveChangesAsync();

            return pageView;
        }

        // DELETE api/<PageViewController>/5
        [HttpDelete("{id}")]
        public ActionResult<PageView> DeletePageView(int id)
        {
            var pageView = _context.PageView.Where(x => x.Id == id).SingleOrDefault();

            if (pageView == null)
                return NotFound();

            _context.PageView.Remove(pageView);
            _context.SaveChangesAsync();

            return pageView;
        }
    }
}
