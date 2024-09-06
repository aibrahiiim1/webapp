using CST_Web.Models;
using CSTWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace CST_Web.Data
{
    public class ApplicationDBContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Category>()
            //    .HasOne(p => p.Categories)
            //    .WithOne(p=>p.e);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set; }
        public DbSet<EquipmentStatus> EquipmentsStatus { get; set; }
        public DbSet<EquipmentFamily> EquipmentsFamily { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Eqclass> Eqclasses { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
