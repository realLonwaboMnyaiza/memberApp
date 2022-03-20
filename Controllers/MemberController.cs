using app.DAL;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger _log;
        public MemberController(AppDbContext context,
                                ILogger log)
        {
            _context = context;
            _log = log;
        }

        [HttpGet("/api/v1/members")]
        public IEnumerable<Member> GetMembers()
        {
            return _context.Member.ToList();
        }
    }
}
