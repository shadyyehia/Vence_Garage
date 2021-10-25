using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    public class BaseEntity
    {        
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
