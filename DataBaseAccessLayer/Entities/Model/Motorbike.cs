using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Model
{
   
    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate) 
        {
            LicensePlate = licensePlate;
        }

    }
}
