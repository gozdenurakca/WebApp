using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportSchoolProject.Models;

namespace SportSchoolProject
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<MajorAdmin> MajorAdmins { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<BranchAdmin> BranchAdmins { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Login>().HasNoKey();
            
            modelBuilder.Entity<BranchAdmin>()
                .HasOne(b => b.User)          // BranchAdmin'in User ile ilişkisi
                .WithOne()                    // User ve BranchAdmin arasındaki ilişki
                .HasForeignKey<BranchAdmin>(b => b.UserId); // UserId foreign key olarak kullanılıyor
            
            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.User)           // Trainer'ın User ile ilişkisi
                .WithOne()                     // User ve Trainer arasındaki ilişki
                .HasForeignKey<Trainer>(t => t.UserId);  // UserId foreign key olarak kullanılıyor
            
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)           // Student'ın User ile ilişkisi
                .WithOne()                     // User ve Student arasındaki ilişki
                .HasForeignKey<Student>(s => s.UserId);  // UserId foreign key olarak kullanılıyor
            
        }
        
    }
}