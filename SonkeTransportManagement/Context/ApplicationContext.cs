using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SonkeTransportManagement.Models;
using System.Collections.Generic;

namespace SonkeTransportManagement.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<RequesterRequest> requests { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Roles> roles { get; set; }
    }
}
