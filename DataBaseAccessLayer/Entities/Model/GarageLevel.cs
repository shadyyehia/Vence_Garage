using Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
   
    public class GarageLevel : BaseEntity
    {
        public GarageLevel()
        {
            Spots = new List<GarageSpot>();
        }
        public Guid ID { get; set; }

        
        public int LevelNumber { get; set; }

        [IsNotEmpty(1, ErrorMessage = "At least one spot is required")]
        public List<GarageSpot> Spots { get; set; }
    }
}
