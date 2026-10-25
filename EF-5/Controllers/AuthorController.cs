using EF_5.Model;
using EF_5.Repository;
using EF_5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AutherService _service;
        public AuthorController(AutherService authorsService)
        {
            _service = authorsService;
        }

        [HttpGet]
        public async Task<IActionResult> getAuthors()
        {
            try
            {
                var authorData = await _service.GetAuthors();
                return Ok(authorData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Authors entity)

        {
            try
            {
                var result = await _service.AddAuthor(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAuthors(int id)
        {
            try
            {
                var result = await _service.DeleteAuthor(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateAuthors([FromBody] Authors entity)
        {
            try
            {
                var result = await _service.UpdateAuthor(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
