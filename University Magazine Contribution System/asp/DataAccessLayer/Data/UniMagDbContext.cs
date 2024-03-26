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

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Contribution>().ToTable("Contributions");
            modelBuilder.Entity<Student>().ToTable("students");
                    

            //modelBuilder.Entity<StudentUserLink>()
            //        .HasOne(l => l.User)
            //        .WithOne(u => u.studentUserLink)
            //        .HasForeignKey<StudentUserLink>(l => l.UserLoginName);
            modelBuilder.Entity<Faculty>().ToTable("faculties");
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<User_Faculty>().ToTable("user_faculties");
            modelBuilder.Entity<SystemParameter>().ToTable("systemParameters").HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}
