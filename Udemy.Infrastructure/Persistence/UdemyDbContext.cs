using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;

namespace Udemy.Infrastructure.Persistence;

public class UdemyDbContext : DbContext
{
    internal DbSet<Content> Contents { get; set; }
    internal DbSet<Comment> Comments { get; set; }
    internal DbSet<Course> Courses { get; set; }
    internal DbSet<CourseTag> CourseTags { get; set; }
    internal DbSet<Like> Likes { get; set; }
    internal DbSet<Module> Modules { get; set; }
    internal DbSet<Rating> Ratings { get; set; }
    internal DbSet<User> Users { get; set; }
    internal DbSet<UserCourse> UserCourses { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=UdemyDb;User Id=sa;Password=Your_password123;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserCourse>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        //modelBuilder.Entity<UserCourse>()
        //    .HasOne(uc => uc.User)
        //    .WithMany(u => )
    }
}