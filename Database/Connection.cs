using Microsoft.EntityFrameworkCore;

namespace Database
{
  public class Context : DbContext
  {
    public Context(){}
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Models.Book> Books { get; set; }
    private IConfiguration Configuration { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connectionString = ConfigurationExtensions.GetConnectionString(Configuration, "BloggingDatabase");
      ServerVersion version = ServerVersion.AutoDetect(connectionString);

      optionsBuilder.UseMySql(connectionString, version);
    }
  }
}