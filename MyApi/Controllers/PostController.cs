using MyApi.Domain.Models;
using MyApi.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Infrastructure.Data.Context;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            List<Post> posts = await _service.GetAll();
            if (posts == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(posts);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Post post = await _service.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(post);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _service.Create(post));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Post>> Update([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _service.Update(post));
            }
            catch (Exception exception) 
            { 
                return BadRequest(exception); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                await _service.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }          
        }
    }
}
