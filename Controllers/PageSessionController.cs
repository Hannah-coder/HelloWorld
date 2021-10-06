using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageSessionController : ControllerBase
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
            var pageSessions = _context.PageSession.Include(x => x.Session).Include(x => x.Page).ToList();

            return pageSessions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns>List of Seesions of page</returns>
        [HttpGet("ByPage/{pageId}")]
        public IEnumerable<PageSession> GetPageSessions(int pageId)
        {
            var pageSessions = _context.PageSession.ToList().Where(x => x.PageId == pageId);

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
            PageSession session = _context.PageSession.Single(x => x.Id == id);

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
            _context.SaveChangesAsync();

            return session;
            //return CreatedAtAction(nameof(_context.PageSession.Add), new { id = session.Id });
        }

        /// <summary>
        /// Deletes the page session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<PageSession> DeletePageSession(int id)
        {
            PageSession session = _context.PageSession.Single(x => x.Id == id);

            if (session == null)
                return NotFound();

            _context.PageSession.Remove(session);
            _context.SaveChangesAsync();

            return session;
            //return CreatedAtAction(nameof(_context.PageSession.Remove), new { id = session.Id });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns>List of pages sessions removed</returns>
        [HttpDelete("DeleteBy/{pageId}")]
        public IEnumerable<PageSession> DeletePagesSession(int pageId)
        {
            var session = _context.PageSession.ToList().Where(x => x.PageId == pageId);

            //if (session == null)
               //return NotFound();
            
            foreach(var page in session)
                _context.PageSession.Remove(page);
            
            _context.SaveChangesAsync();

            return session;
            //return CreatedAtAction(nameof(_context.PageSession.Remove), new { id = session.Id });
        }
    }
}
