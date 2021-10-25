using Contracts;
using Entities;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GarageRepository : RepositoryBase<GarageSimulation>, IGarageRepository
    { 
        public GarageRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext) 
        {
           
        }
       

     
        public Tuple<bool, GarageSpot> EnterVehicle(Vehicle vehicle)
        {
            //loop levels 

            var garage = _table.FirstOrDefault();
            foreach (var level in garage?.GarageLevels)
            {
                //loop spots in level
                //decide to accept or reject the vehicle
                foreach (var spot in level.Spots)
                {

                    if (spot.CurrentParkedVehicle == null)
                    {
                        spot.CurrentParkedVehicle = vehicle;
                        vehicle.Status = Enums.VehicleStatus.Inside;
                        return new Tuple<bool, GarageSpot>(true,spot);
                    }
                }
            }
            vehicle.Status = Enums.VehicleStatus.OutSide;
            return new Tuple<bool, GarageSpot>(false,null);
        }

        
    }
}
