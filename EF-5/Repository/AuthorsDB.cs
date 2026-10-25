using EF_5.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_5.Repository
{
    public class AuthorsDB : DbContext
    {
        public AuthorsDB(DbContextOptions<AuthorsDB> options) : base(options)
        {
        }
        public DbSet<Authors> AuthorsTable { get; set; }
    }
}
