using app.Models;

namespace app.DAL
{
    public interface IMemberRepository
    {
        Task<Member> GetMember(int id);

        IEnumerable<Member> GetMembers();
    }
}
