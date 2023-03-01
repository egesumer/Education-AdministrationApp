using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementKD13.Domain;
using SchoolManagementKD13.Domain.Common;
using SchoolManagementKD13.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Persistence.Contexts
{
    public class SchoolManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().Property(x=>x.FirstName).HasMaxLength(50).IsRequired();
            builder.Entity<Student>().Property(x => x.LastName).HasMaxLength(50).IsRequired();

            builder.Entity<School>().Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Entity<School>().HasMany(x => x.Students).WithOne(x => x.School).HasForeignKey(x => x.SchoolId);

            builder.Entity<School>().HasData(new School { Id = Guid.NewGuid(), Name="Boğaziçi" });
            builder.Entity<School>().HasData(new School { Id = Guid.NewGuid(), Name = "ODTÜ" });

            base.OnModelCreating(builder);
        }

        //Her entity için yapacağım bir işi her entity'de ayrı ayrı yapmak yerine tek merkezden yöneteceğim. (Interceptor)
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entity'ler üzerinde yapılan değişiklikleri takip ederek bu verilere ulaşabilmemizi sağlar.

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreationDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.Now,
                    //Delete işinde hata vermemesi için 
                    _ => DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
