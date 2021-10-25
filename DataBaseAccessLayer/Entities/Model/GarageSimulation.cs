using Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entities.Model
{   
    public class GarageSimulation : BaseEntity 
    {
        public GarageSimulation(int levelCount, int spotCountPerLevel )
        {
            LevelCount = levelCount;
            SpotCountPerLevel = spotCountPerLevel;
            //install the garage parking spots
            Build_Garage();
        }

       
       
        public Guid ID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please set Garage Levels in configuration file to be at least {1}")]
        public int LevelCount { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Please set Garage Spots in configuration file to be at least {1}")]
        public int SpotCountPerLevel { get; set; }

        
        public List<GarageLevel> GarageLevels{ get; set; }


        void Build_Garage()
        {

            GarageLevels = new List<GarageLevel>();
            for (int i = 0; i < LevelCount; i++)
            {
                var _garageLevel = new GarageLevel() { CreatedBy = "Admin", CreatedAt = DateTime.Now };
                _garageLevel.LevelNumber = i;
                for (int j = 0; j < SpotCountPerLevel; j++)
                {
                    _garageLevel.Spots.Add(new GarageSpot() { CreatedBy = "Admin", CreatedAt = DateTime.Now, SpotNumber = "[" + i + " - " + j + "]" });    
                }
                GarageLevels.Add(_garageLevel);
            }
           
        }


    }
}
