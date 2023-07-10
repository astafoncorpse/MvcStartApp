using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models
{
    public sealed class RequestContext : DbContext
    {
        // Ссылка на таблицу RequestTable
        public DbSet<Request> RequestTable { get; set; }

        // Логика взаимодействия с таблицами в БД
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
