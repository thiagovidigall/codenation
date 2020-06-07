using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Submission> SubMissions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>(e => {
                
                e.ToTable(nameof(Submission).ToLower());
                e.Property(x => x.User_Id).HasColumnName("user_id");
                e.Property(x => x.Challenge_Id).HasColumnName("challenge_id");
                e.Property(x => x.Score).HasColumnName("score").HasColumnType("decimal(9,2)");
                e.Property(x => x.Created_At).HasColumnName("created_at");

                e.HasKey(x => new { x.User_Id, x.Challenge_Id });

                e.HasOne<User>(x => x.User).WithMany(u => u.Submissions).HasForeignKey(x => x.User_Id);
                e.HasOne<Challenge>(x => x.Challenge).WithMany(x => x.Submissions).HasForeignKey(x => x.Challenge_Id);
            });           
              

            modelBuilder.Entity<Candidate>(e =>
            {
                e.ToTable(nameof(Candidate).ToLower());
                e.Property(x => x.User_Id).IsRequired().HasColumnName("user_id");
                e.Property(x => x.Acceleration_Id).IsRequired().HasColumnName("acceleration_id");
                e.Property(x => x.Company_Id).IsRequired().HasColumnName("company_id");
                e.Property(x => x.Status).IsRequired().HasColumnName("status"); ;
                e.Property(x => x.Created_At).IsRequired().HasColumnName("created_at"); ;


                e.HasKey(x => new { x.User_Id, x.Acceleration_Id, x.Company_Id });

                e.HasOne<User>(x => x.User).WithMany(x => x.Candidates).HasForeignKey(x => x.User_Id).IsRequired();
                e.HasOne<Acceleration>(x => x.Acceleration).WithMany(x => x.Candidates).HasForeignKey(x => x.Acceleration_Id).IsRequired();
                e.HasOne<Company>(x => x.Company).WithMany(x => x.Candidates).HasForeignKey(x => x.Company_Id).IsRequired();
            });


            modelBuilder.Entity<Acceleration>(e =>
            {
                e.ToTable(nameof(Acceleration).ToLower());
                e.Property(x => x.Id).IsRequired().HasColumnName("id");
                e.Property(x => x.Challenge_Id).IsRequired().HasColumnName("challenge_id");
                e.Property(x => x.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
                e.Property(x => x.Slug).IsRequired().HasColumnName("slug").HasMaxLength(50);
                e.Property(x => x.Created_At).IsRequired().HasColumnName("created_at");

                e.HasKey(x => x.Id );
                e.HasOne<Challenge>(x => x.Challenge).WithMany(x => x.Accelerations).HasForeignKey(a => a.Challenge_Id).IsRequired();


            });

        }
    }
}