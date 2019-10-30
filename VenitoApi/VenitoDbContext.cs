namespace VenitoApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VenitoDbContext : DbContext
    {
        public VenitoDbContext()
            : base("name=VenitoDbContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeFollowing> EmployeeFollowings { get; set; }
        public virtual DbSet<EmployeeHistory> EmployeeHistories { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<OpenPosition> OpenPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.about)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeFollowings)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeHistory>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeHistory>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.about)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .HasMany(e => e.OpenPositions)
                .WithRequired(e => e.Employer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.EmployeeFollowings)
                .WithRequired(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.OpenPositions)
                .WithRequired(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OpenPosition>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
