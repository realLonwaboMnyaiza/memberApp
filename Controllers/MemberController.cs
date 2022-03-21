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
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MemberController> _log;
        public MemberController(IMemberRepository memberRepository,
                                IMapper mapper,
                                ILogger<MemberController> log)
        {
            _repository = memberRepository;
            _mapper = mapper;
            _log = log;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            try
            {
                var member = await _repository.GetMember(id);
                if (member is null)
                {
                    return NotFound();
                }

                var memberDto = _mapper.Map<MemberDto>(member);
                return Ok(memberDto);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetMembers()
        {
            try
            {
                var members = _repository.GetMembers();
                var membersDto = _mapper.Map<List<MemberDto>>(members);
                return Ok(membersDto);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private void Log(string message)
        {
            _log.LogInformation(message);
        }
    }
}
