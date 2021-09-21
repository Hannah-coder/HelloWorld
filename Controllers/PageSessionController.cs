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
    public class PageSessionController : Controller
    {
        private readonly ILogger<PageSessionController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageSessionController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The database context.</param>
        public PageSessionController(Microsoft.Extensions.Logging.ILogger<PageSessionController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets the page sessions.
        /// </summary>
        /// <returns>List of page sessions</returns>
        [HttpGet]
        public IEnumerable<PageSession> GetPageSessions()
        {
            var pageSessions = _context.PageSession.ToList();

            return pageSessions;
        }

        /// <summary>
        /// Gets the page session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Page session if found</returns>
        [HttpGet("{id}")]
        public ActionResult<PageSession> GetPageSession(int id)
        {
            PageSession session = _context.PageSession.Where(x => x.Id == id).SingleOrDefault();

            if (session == null)
                return NotFound();

            return session;
        }

        /// <summary>
        /// Creates the page session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PageSession> CreatePageSession(PageSession session)
        {
            _context.PageSession.Add(session);

            return CreatedAtAction(nameof(_context.PageSession.Add), new { id = session.Id });
        }

        /// <summary>
        /// Deletes the page session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<PageSession> DeletePageSession(int id)
        {
            PageSession session = _context.PageSession.Where(x => x.Id == id).SingleOrDefault();

            if (session == null)
                return NotFound();

            _context.PageSession.Remove(session);

            return CreatedAtAction(nameof(_context.PageSession.Remove), new { id = session.Id });
        }
    }
}
