using Microsoft.EntityFrameworkCore;


namespace API_RESTful.Models
{
    public class MyDBcontext: DbContext
    {
        public MyDBcontext(DbContextOptions<MyDBcontext> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
    }
}
