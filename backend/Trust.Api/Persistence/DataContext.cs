using Trust.Auth.Entities;
using Trust.Auth.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Trust.Api.Persistence
{
    public class DataContext : DbContext, IAuthContext
    {
        public DbSet<Account> Accounts { get; set; }

        private readonly IConfiguration m_Configuration;

        public DataContext(IConfiguration configuration)
        {
            m_Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(m_Configuration.GetConnectionString("Development"));
        }
    }
}
