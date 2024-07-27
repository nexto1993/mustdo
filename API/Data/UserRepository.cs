using API.DTOs;
using API.Entities;
using API.Helper;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository(ApplicationDbContext context, IMapper mapper) : IUserRepository
    {
        public async Task<MemberDto?> GetMemberAsync(string username)
        {
            return await context.Appusers
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = context.Appusers.ProjectTo<MemberDto>(mapper.ConfigurationProvider)
                .AsNoTracking();
            return await PagedList<MemberDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);

        }


        public async Task<Appuser?> GetUserByIdAsync(int id)
        {
            return await context.Appusers.FindAsync(id);
        }

        public async Task<Appuser?> GetUserByUsernameAsync(string username)
        {
            return await context.Appusers
                .Include(x => x.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<Appuser>> GetUsersAsync()
        {
            return await context.Appusers
                .Include(x => x.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(Appuser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
    }
