using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper 
    { 
        private RepositoryContext _repoContext; 
 
        private ICarRepository _carRepo;       
        
        public ICarRepository CarRepo 
        { 
            get 
            { 
                if (_carRepo == null) 
                {
                    _carRepo = new CarRepository(_repoContext); 
                } 
                return _carRepo; 
            } 
        }


        private IMotorBikeRepository _motorBikeRepo;

        public IMotorBikeRepository MotorBikeRepo
        {
            get
            {
                if (_motorBikeRepo == null)
                {
                    _motorBikeRepo = new MotorBikeRepository(_repoContext);
                }
                return _motorBikeRepo;
            }
        }



        private IGarageRepository _garageRepo;

        public IGarageRepository GarageRepo
        {
            get
            {
                if (_garageRepo == null)
                {
                    _garageRepo = new GarageRepository(_repoContext);
                }
                return _garageRepo;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext) 
        { 
            _repoContext = repositoryContext; 
        } 
        
        public void Save() 
        {
            _repoContext.SaveChanges();
        } 
    }
}
