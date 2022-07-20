using MyApi.Domain.Models;
using MyApi.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace MyApi.Infrastructure.Data.Repositories
{
    public class PostRepository
    {
        private readonly DbPostContext _context;

        public PostRepository(DbPostContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<Post> GetById(int id)
        {
            Post post = await _context.Posts.FindAsync(id);

            return post;
        }

        public async Task<Post> Create(Post post)
        {          
            _context.Posts.Add(post);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }

            return post;
        }
        
        public async Task<Post> Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbException)
            {
                throw dbException;
            }
            catch (Exception)
            {
                throw;
            }      

            return post;
        }

        public async Task Delete(int id)
        {
            Post post = GetById(id).Result;

            _context.Entry(post).State = EntityState.Deleted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbException)
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
