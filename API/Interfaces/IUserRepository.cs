using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(Appuser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Appuser>> GetUsersAsync();
        Task<Appuser?> GetUserByIdAsync(int id);
        Task<Appuser?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto?> GetMemberAsync(string username);
    }
}
