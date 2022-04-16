using cidade_alta_criminal_code.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using cidade_alta_criminal_code.Data.Dtos.UserDto;

namespace cidade_alta_criminal_code.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
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

        public DbSet<cidade_alta_criminal_code.Models.CriminalCode> CriminalCodes { get; set; }

        public DbSet<cidade_alta_criminal_code.Models.Status> Status { get; set; }

        public DbSet<cidade_alta_criminal_code.Data.Dtos.UserDto.CreateUserDto> CreateUserDto { get; set; }
    }
}