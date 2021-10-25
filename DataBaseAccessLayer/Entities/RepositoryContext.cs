using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext() 
            : base() 
        {
            
        }

        public DbSet<Motorbike> Bikes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<GarageSimulation> Garage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("GarageDB");
        }
       

        public override int SaveChanges()
        {

            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }

            return base.SaveChanges();
        }
    }
}
