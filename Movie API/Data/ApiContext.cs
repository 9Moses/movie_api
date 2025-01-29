using Microsoft.EntityFrameworkCore;
using Movie_API.Models;
    
namespace Movie_API.Data
{
public class ApiContext : DbContext
{
    public DbSet<MovieApi>? Movies { get; set; }
    
    public ApiContext(DbContextOptions<ApiContext> options):base(options){}
}
}