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
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The database context.</param>
        public RequestController(ILogger<RequestController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets the requests.
        /// </summary>
        /// <returns>List of Requests</returns>
        [HttpGet]
        public IEnumerable<Request> GetRequests()
        {
            var requests = _context.Request.ToList();

            return requests;
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Request if found</returns>
        [HttpGet("{id}")]
        public ActionResult<Request> GetRequest(int id)
        {
            var request = _context.Request.Where(x => x.Id == id).SingleOrDefault();

            if (request == null)
                return NotFound();

            return request;
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request request)
        {
            _context.Request.Add(request);

            return CreatedAtAction(nameof(_context.Request.Add), new { id = request.Id });
        }

        /// <summary>
        /// Deletes the request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Request> DeleteRequest(int id)
        {
            var request = _context.Request.Where(x => x.Id == id).SingleOrDefault();

            if (request == null)
                return NotFound();

            _context.Request.Remove(request);

            return CreatedAtAction(nameof(_context.Request.Remove), new { id = request.Id });
        }
    }
}
