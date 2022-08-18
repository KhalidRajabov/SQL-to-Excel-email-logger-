using Microsoft.EntityFrameworkCore;
using WebApiLogger.Data.Entities;

namespace WebApiLogger.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<ExcelData> ExcelDatas { get; set; }
    }
}
