using EF_5.Model;
using EF_5.Repository;
using Microsoft.EntityFrameworkCore;

namespace EF_5.Services
{
    public class AutherService
    {
        private readonly AuthorsDB _authors;
        public AutherService(AuthorsDB authors)
        {
            _authors = authors;
        }

        public async Task<List<Authors>> GetAuthors()
         {
            var authorData = await _authors.AuthorsTable.ToListAsync();
            return authorData;
        }

        public async Task<string> AddAuthor(Authors entity)
        {
            try
            {
                _authors.AuthorsTable.Add(entity);
                await _authors.SaveChangesAsync();
                return "Author added successfully";
            }
            catch (Exception ex)
            { 
                return "Error occurred while adding author " + ex.Message;
            }
           
        }

        public async Task<string> DeleteAuthor(int id)
        {
            try
            {
                var entity = await _authors.AuthorsTable.FindAsync(id);
                if (entity == null)
                {
                    return "Author not found";
                }
                _authors.AuthorsTable.Remove(entity);
                await _authors.SaveChangesAsync();
                return "Author deleted successfully";
            }
            catch (Exception ex)
            {
                return "Error occurred while deleting author " + ex.Message;
            }
        }

        public async Task<string> UpdateAuthor(Authors entity)
        {
            try
            {
                var existingAuthors = await _authors.AuthorsTable.FindAsync(entity.AuthorId);
                if (existingAuthors == null)
                {
                    return "Author not found";
                }
                existingAuthors.Author_Name = entity.Author_Name;
                existingAuthors.Author_Age = entity.Author_Age;
                existingAuthors.Author_EXP = entity.Author_EXP;
                _authors.AuthorsTable.Update(existingAuthors);
                await _authors.SaveChangesAsync();
                return "Author updated successfully";
            }
            catch (Exception ex)
            {
                return "Error occurred while updating author " + ex.Message;
            }
        }

    }
}
