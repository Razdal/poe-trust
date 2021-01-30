using Trust.Auth.Entities;
using Trust.Auth.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Trust.Auth.Tests
{
    internal class MockContext : DbContext, IAuthContext
    {
        public DbSet<Account> Accounts { get; set; }

        public MockContext(DbContextOptions<MockContext> options) : base(options) { }
    }
}
