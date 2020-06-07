using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<SubMission> SubMissions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubMission>().HasKey(x => new { x.User_Id, x.Challenge_Id });
            modelBuilder.Entity<Candidate>().HasKey(x => new { x.User_Id, x.Acceleration_Id, x.Company_Id });
            modelBuilder.Entity<Acceleration>()
                .HasOne<Challenge>(a => a.Challenge)
                .WithMany(c => c.Accelerations)
                .HasForeignKey(a => a.Challenge_Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Acceleration_Challenge");
        }

        //public CodenationContext(DbContextOptions<CodenationContext> options) : base(options)
        //public CodenationContext()
        //{             
        //    Database.EnsureCreated();
        //}
    }
}