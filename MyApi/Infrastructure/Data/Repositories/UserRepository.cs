using MyApi.Domain.Models;
using MyApi.Infrastructure.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace MyApi.Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly DbPostContext _context;

        public UserRepository(DbPostContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            List<ApplicationUser> users = await _context.User.ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            ApplicationUser user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<ApplicationUser> Create(ApplicationUser user)
        {
            _context.User.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public async Task Delete(string id)
        {
            ApplicationUser user = GetById(id).Result;

            _context.User.Remove(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
