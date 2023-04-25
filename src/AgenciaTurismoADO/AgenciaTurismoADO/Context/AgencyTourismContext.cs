using AgenciaTurismoADO.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismoADO.Context
{
    public class AgencyTourismContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasOne(x=>x.Origin).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>().HasOne(x => x.Destination).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>().HasOne(x => x.Hotel).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>().HasOne(x => x.Ticket).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>().HasOne(x => x.Client).WithMany().OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
