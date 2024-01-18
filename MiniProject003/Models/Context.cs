using Microsoft.EntityFrameworkCore;

namespace MiniProject003.Models
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PersonNationality> PersonsNationalities { get; set; }
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonNationality>()
                .HasOne<Person>(pn => pn.Person)
                .WithMany(p => p.PersonsNationalities)
                .HasForeignKey(pn => pn.PersonId);
            modelBuilder.Entity<PersonNationality>()
                .HasOne<Nationality>(pn => pn.Nationality)
                .WithMany(n => n.PersonsNationalities)
                .HasForeignKey(pn => pn.NationalityId);
        }
    }
}
