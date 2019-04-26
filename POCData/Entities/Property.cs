using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;

namespace POCData
{
    public interface IPropertyRepository
    {
        List<Property> Get(Property entity);
        Property Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Property item);
    }

    public class Property :BaseEntity
    {
        public int? Type { get; set; }
        public string Address { get; set; }    
    }
}
