using Contracts;
using Entities;
using Entities.Model;

namespace Repository
{
    public class MotorBikeRepository : RepositoryBase<Motorbike>, IMotorBikeRepository 
    { 
        public MotorBikeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) 
        { 
        } 
    }
}
