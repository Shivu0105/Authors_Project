using EF_5.Model;
using EF_5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EF_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AuthorsDB _authors;
        public AuthorController(AuthorsDB authors)
        {
            _authors = authors;
        }

        [HttpGet]
        public async Task<IActionResult> getAuthors()
        {
            try
            {
                var authorData = await _authors.AuthorsTable.ToListAsync();
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
                _authors.AuthorsTable.Add(entity);
                await _authors.SaveChangesAsync();
                return Ok(entity);
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
                var entity = await _authors.AuthorsTable.FindAsync(id);
                if (entity == null)
                {
                    return NotFound("Author not found");
                }
                _authors.AuthorsTable.Remove(entity);
                await _authors.SaveChangesAsync();
                return Ok("Author deleted successfully");
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
                var existingAuthors = await _authors.AuthorsTable.FindAsync(entity.AuthorId);
                if(existingAuthors == null)
                {
                    return NotFound("Author not found");
                }
                existingAuthors.AuthorId = entity.AuthorId;
                existingAuthors.Author_Name = entity.Author_Name;
                existingAuthors.Author_Age = entity.Author_Age;
                existingAuthors.Author_EXP = entity.Author_EXP;

                _authors.AuthorsTable.Update(existingAuthors);
                await _authors.SaveChangesAsync();
                return Ok("Data updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
