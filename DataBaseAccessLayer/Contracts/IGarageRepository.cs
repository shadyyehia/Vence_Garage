using Entities.Model;
using System;

namespace Contracts
{
    public interface IGarageRepository : IRepositoryBase<GarageSimulation>
    {
        Tuple<bool,GarageSpot> EnterVehicle(Vehicle vehicle);
     
       

    }
}
