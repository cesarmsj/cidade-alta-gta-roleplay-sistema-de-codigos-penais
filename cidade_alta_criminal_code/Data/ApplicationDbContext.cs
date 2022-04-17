using cidade_alta_criminal_code.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cidade_alta_criminal_code.Data
{
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("User");

            builder.Entity<Status>().HasKey(t => t.Id);
            builder.Entity<Status>().HasData(new Models.Status { Id = 1, Name = "Ativo" });
            builder.Entity<Status>().HasData(new Models.Status { Id = 2, Name = "Inativo" });

            builder.Entity<CriminalCode>().HasKey(t => t.Id);
            builder.Entity<CriminalCode>().HasOne(t => t.CreateUser).WithMany(t => t.CreateUsers).HasForeignKey(t => t.CreateUserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CriminalCode>().HasOne(t => t.UpdateUser).WithMany(t => t.UpdateUsers).HasForeignKey(t => t.UpdateUserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CriminalCode>().HasOne(t => t.Status).WithMany(t => t.CriminalCodeStatus).HasForeignKey(t => t.StatusId).OnDelete(DeleteBehavior.ClientCascade);

 


        }

        public DbSet<cidade_alta_criminal_code.Models.CriminalCode> CriminalCodes { get; set; }

        public DbSet<cidade_alta_criminal_code.Models.Status> Status { get; set; }

    }
}