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

        
    }
}