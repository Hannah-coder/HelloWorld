using API.Models;
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
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The database context.</param>
        public PageController(ILogger<PageController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// Gets the pages.
        /// </summary>
        /// <returns>List of pages</returns>
        [HttpGet]
        public IEnumerable<Page> GetPages()
        {
            var pages = _context.Page.ToList();
            
            return pages;
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Page if found</returns>
        [HttpGet("single/{id}")]
        public ActionResult<Page> GetPage(int id)
        {
            Page page = _context.Page.Single(x => x.Id == id);

            if (page == null)
                return NotFound();

            return page;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Page if found</returns>
        [HttpGet("{page_url}")]
        public ActionResult<Page> GetPage(string url)
        {
            Page page = _context.Page.Single(x => x.Page_Url == url);

            if (page == null)
                return NotFound();

            return page;
        }

        /// <summary>
        /// Creates the page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpPost]
        public Page CreatePage(Page page)
        {
            _context.Page.Add(page);
            _context.SaveChangesAsync();

            return page;
        }

        /// <summary>
        /// Deletes the page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Page deleted if found</returns>
        [HttpDelete("Single/{id}")]
        public ActionResult<Page> DeletePage(int id)
        {
            Page page = _context.Page.Where(x => x.Id == id).SingleOrDefault();

            if (page == null)
                return NotFound();

            _context.Page.Remove(page);
            _context.SaveChangesAsync();

            return page;
            //return CreatedAtAction(nameof(_context.Page.Remove), new { id = page.Id });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Page deleted if found</returns>
        [HttpDelete("{page_url}")]
        public ActionResult<Page> DeletePage(string url)
        {
            var page = _context.Page.Single(x => x.Page_Url == url);

            if (page == null)
                //return NotFound();

            _context.Page.Remove(page);
            _context.SaveChangesAsync();

            //return page;
            //return CreatedAtAction(nameof(_context.Page.Remove), new { id = page.Id });
        //}
    }
}
