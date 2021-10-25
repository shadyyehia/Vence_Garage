using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper 
    { 
     
        ICarRepository CarRepo { get; } 
        IMotorBikeRepository MotorBikeRepo { get; }
        void Save(); 
    }
}
