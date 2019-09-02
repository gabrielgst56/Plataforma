using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IFSP.Plataforma.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public DataContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Chatbot> Chatbots { get; set; }

        public DbSet<Dialogue> Dialogues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ChatbotMap());
            modelBuilder.ApplyConfiguration(new DialogueMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings'
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseNpgsql(config.GetConnectionString("BasePlataforma"));
        }
    }
}
