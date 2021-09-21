using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<PageSessionController> _logger;
        private readonly MetricsDbContext _context;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PageSessionController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The database context.</param>
        public SessionController(ILogger<PageSessionController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<APIController>        
        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns>List of sessions</returns>
        [HttpGet]
        public IEnumerable<Session> GetSessions()
        {
            var sessions = _context.Session.ToList();

            return sessions;
        }

        // GET api/<APIController>/5        
        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Session if found</returns>
        [HttpGet("{id}")]
        public ActionResult<Session> GetSession(int id)
        {
            Session session = _context.Session.Where(x => x.Id == id).SingleOrDefault();

            if (session == null)
                return NotFound();

            return session;
        }

        // POST api/<APIController>        
        /// <summary>
        /// Creates the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Session> CreateSession(Session session)
        {
            _context.Session.Add(session);

            return CreatedAtAction(nameof(_context.Session.Add), new { id = session.Id });
        }

        // DELETE api/<APIController>/5        
        /// <summary>
        /// Deletes the session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Session> DeleteSession(int id)
        {
            Session session = _context.Session.Where(x => x.Id == id).SingleOrDefault();

            if (session == null)
                return NotFound();

            _context.Session.Remove(session);
            
            return CreatedAtAction(nameof(_context.Session.Remove), new { id = session.Id });
        }


    }
}
