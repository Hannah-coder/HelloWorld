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

        public PageViewController(ILogger<PageViewController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PageView> GetPets()
        {
            var pages = _context.PageView.ToList();

            return pages;
        }

        [HttpGet("single/{id}")]
        public ActionResult<PageView> GetPageView(int id)
        {
            var page = _context.PageView.Single(x => x.Id == id);

            if (page == null)
                return NotFound();

            return page;
        }

        [HttpGet("ByURLSection1/{URLSection1}")]
        public IEnumerable<PageView> GetPageSessions(string pageURL)
        {
            var pageViews = _context.PageView.ToList().Where(x => x.URLSection1 == pageURL);

            return pageViews;
        }

        [HttpPost]
        public ActionResult<PageView> CreatePageSession(PageView page)
        {
            _context.PageView.Add(page);
            _context.SaveChangesAsync();

            return page;
            //return CreatedAtAction(nameof(_context.PageSession.Add), new { id = session.Id });
        }
    }
}
