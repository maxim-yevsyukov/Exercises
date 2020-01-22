using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUD_EF.Models
{
    public partial class AdventureWorks2012Context : DbContext
    {
        public AdventureWorks2012Context()
        {
        }

        public AdventureWorks2012Context(DbContextOptions<AdventureWorks2012Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PMO00011;Database=AdventureWorks2012;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Person");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.NameFirst)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameLast)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
