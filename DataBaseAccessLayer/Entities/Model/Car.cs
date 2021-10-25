using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
  
    public class Car : Vehicle
    {
        public Car(string licensePlate)
        {
            LicensePlate = licensePlate;
        }

    }
}
