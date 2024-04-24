using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class UniMagDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Contribution> contributions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> faculty { get; set; }
        public DbSet<User_Faculty> user_Faculties { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<SystemParameter> systemParameters { get; set; }
        public UniMagDbContext(DbContextOptions options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contribution>().ToTable("Contributions");
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Comment>().ToTable("Comments");

            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.user_Faculties).WithOne(uf => uf.faculty).HasForeignKey(i => i.FacultyId);


            modelBuilder.Entity<User>()
                .HasMany(uf => uf.user_Faculties).WithOne(u => u.user).HasForeignKey(l => l.LoginName);
            modelBuilder.Entity<SystemParameter>().ToTable("SystemParameters").HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}
