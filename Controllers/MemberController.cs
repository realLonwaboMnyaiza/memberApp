using app.DAL;
using app.Dtos;
using app.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("/api/v1/members/")]
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

        [HttpGet("{id}")]
        public IActionResult GetMember(int id)
        {
            var member = _context.Member.Find(id);
            if (member is null)
            {
                return NotFound();
            }

            var memberDto =  _mapper.Map<MemberDto>(member);
            return Ok(memberDto);
        }

        [HttpGet]
        public IActionResult GetMembers()
        {
            var members = _context.Member;
            var membersDto = _mapper.Map<List<MemberDto>>(members);
            return Ok(membersDto); 
        }
    }
}
