using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{

    public class GarageSpot : BaseEntity
    {         
        
        public Guid ID { get; set; }

        public string SpotNumber{ get; set; }                

        public Vehicle CurrentParkedVehicle{ get; set; }
    }
}
