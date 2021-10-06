using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerInformationController : Controller
    {
        private readonly ILogger<ServerInformationController> _logger;
        private readonly MetricsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInformationController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public ServerInformationController(ILogger<ServerInformationController> logger, MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<ServerInformationController>
        [HttpGet]
        public IEnumerable<ServerInformation> Get()
        {
            var serverInformation = _context.ServerInformation.ToList();
            
            return serverInformation;
        }

        // GET api/<ServerInformationController>/5
        [HttpGet("{id}")]
        public ActionResult<ServerInformation> Get(int id)
        {
            var serverInformation = _context.ServerInformation.Where(x => x.Id == id).SingleOrDefault();

            if (serverInformation == null)
                return NotFound();

            return serverInformation;
        }

        // POST api/<ServerInformationController>
        [HttpPost]
        public ActionResult<ServerInformation> CreateServerInformation(ServerInformation serverInformation)
        {
            _context.ServerInformation.Add(serverInformation);
            _context.SaveChangesAsync();

            return serverInformation;
        }

        // DELETE api/<ServerInformationController>/5
        [HttpDelete("{id}")]
        public ActionResult<ServerInformation> DeleteServerInformation(int id)
        {
            var serverInformation = _context.ServerInformation.Where(x => x.Id == id).SingleOrDefault();

            if (serverInformation == null)
                return NotFound();

            _context.ServerInformation.Remove(serverInformation);
            _context.SaveChangesAsync();

            return serverInformation;
        }
    }
}
