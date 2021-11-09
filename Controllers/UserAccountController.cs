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
    public class UserAccountController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly MetricsDbContext _context;

        public UserAccountController(ILogger<UserAccountController> logger,
            MetricsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<List<UserAccounts>> GetUserAccountsAsync()
        {
            return await _context.UserAccounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<UserAccounts> GetUser(int id)
        {
            var user = _context.UserAccounts.Single(x => x.UserId == id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult<UserAccounts> CreateUserAccountAsync(UserAccounts user)
        {   
            _context.UserAccounts.Add(user);
            _context.SaveChangesAsync();
            
            return user;
        }

        [HttpDelete("{id}")]
        public ActionResult<UserAccounts> DeleteUser(int id)
        {
            var user = _context.UserAccounts.Single(x => x.UserId == id);

            if (user == null)
                return NotFound();

            _context.UserAccounts.Remove(user);
            _context.SaveChangesAsync();

            return user;
        }
    }
}
