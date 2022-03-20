using app.DAL;
using app.Dtos;
using app.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MemberController> _log;
        public MemberController(AppDbContext context,
                                IMapper mapper,
                                ILogger<MemberController> log)
        {
            _context = context;
            _mapper = mapper;
            _log = log;
        }

        [HttpGet("/api/v1/members")]
        public IEnumerable<MemberDto> GetMembers()
        {
            var member = _context.Member;
            return _mapper.Map<List<MemberDto>>(member);
        }
    }
}
