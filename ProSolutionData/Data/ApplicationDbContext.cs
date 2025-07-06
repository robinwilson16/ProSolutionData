using ProSolutionData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace ProSolutionData.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration _configuration) : DbContext(options)
    {
        public IConfiguration configuration { get; } = _configuration;

        public DbSet<DevolvedAreaPostCodeModel> DevolvedAreaPostCode { get; set; }
        public DbSet<TeamModel> Team { get; set; }
        public DbSet<CourseModel> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DevolvedAreaPostCodeModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<TeamModel>().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<CourseModel>().ToTable(t => t.ExcludeFromMigrations());

            //Unique value
            //modelBuilder.Entity<StudentUniqueReference>().HasIndex(s => s.StudentRef).IsUnique();
        }

        //Rename migration history table
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(
        //        configuration.GetConnectionString("DefaultConnection"),
        //        x => x.MigrationsHistoryTable("__CRI_EFMigrationsHistory", "dbo"));

        //Rename migration history table
    }
}