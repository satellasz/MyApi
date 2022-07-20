using MyApi.Infrastructure.Data.Repositories;
using MyApi.Domain.Models;

namespace MyApi.Domain.Services
{
    public class PostService
    {
        private readonly PostRepository _repository;

        public PostService(PostRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _repository.GetAll();

            return posts;
        }

        public async Task<Post> GetById(int id)
        {
            Post post = await _repository.GetById(id);

            if (post == null)
                throw new ArgumentException("Post não existe");

            return post;
        }

        public async Task<Post> Create(Post post)
        {
            post.Data = DateTime.Now;

            await _repository.Create(post);

            return post;
        }

        public async Task<Post> Update(Post post)
        {
            await _repository.Update(post);

            return post;
        }

        public async Task Delete(int id)
        {
            Post post = _repository.GetById(id).Result;
            if (post == null)
                throw new ArgumentException("Post não existe");

            await _repository.Delete(id);
        }
    }
}
