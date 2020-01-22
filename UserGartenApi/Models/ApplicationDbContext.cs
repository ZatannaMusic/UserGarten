using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserGartenApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        #endregion Constructor

        #region Properties

        public DbSet<User> Users { get; set; }
        public DbSet<UserTitle> UserTitles { get; set; }

        #endregion Properties

        #region Relationships

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasOne(i => i.Title).WithMany(u => u.Users);

            modelBuilder.Entity<UserTitle>().ToTable("UserTitles");
            modelBuilder.Entity<UserTitle>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserTitle>().HasMany(u => u.Users).WithOne(i => i.Title);
        }

        #endregion
    }
}
