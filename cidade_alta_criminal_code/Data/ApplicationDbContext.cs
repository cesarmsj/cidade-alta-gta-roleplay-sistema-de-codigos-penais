using cidade_alta_criminal_code.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cidade_alta_criminal_code.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(t => t.Id);

            builder.Entity<CriminalCode>().HasKey(t => t.Id);
            builder.Entity<CriminalCode>().HasOne(t => t.CreateUser).WithMany(t => t.CreateUsers).HasForeignKey(t => t.CreateUserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CriminalCode>().HasOne(t => t.UpdateUser).WithMany(t => t.UpdateUsers).HasForeignKey(t => t.UpdateUserId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Status>().HasKey(t => t.Id);
            
        }

        public DbSet<cidade_alta_criminal_code.Models.CriminalCode> CriminalCode { get; set; }
    }
}