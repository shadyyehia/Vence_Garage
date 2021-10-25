using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    
    public class Vehicle : BaseEntity
    {      

        [Key]
        [Required]
        public string LicensePlate { get; set; }
        public Enums.VehicleStatus Status { get; set; }
       
       
    }
}
