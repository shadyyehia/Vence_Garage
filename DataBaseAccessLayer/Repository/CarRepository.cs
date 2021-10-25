using Contracts;
using Entities;
using Entities.Model;

namespace Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    { 
        public CarRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) 
        { 
        } 
    }
}
