using Microsoft.EntityFrameworkCore;
using P2_2019GH650_2019AM601.Models;

namespace P2_2019GH650_2019AM601
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<casosReportados> casosReportados { get; set; }
        public DbSet<genero> genero { get; set; }
    }
}
