using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;

namespace HLIMS.Entities
{
    public enum PropertyType
    {
        Apartment=1,
        House
    }
    public class Property :BaseEntity
    {
        public PropertyType? PropertyType { get; set; }
        public string Address { get; set; }    
    }
}
