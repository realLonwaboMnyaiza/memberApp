using app.Models;

namespace app.DAL
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Member> GetMember(int id)
        {
            return await _context.Member.FindAsync(id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _context.Member.AsEnumerable();      
        }
    }
}
