using EF_5.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public async Task 

    }
}
