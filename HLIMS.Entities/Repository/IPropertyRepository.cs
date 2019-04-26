using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLIMS.Entities
{
    public interface IPropertyRepository
    {
        List<Property> Get(Property entity);
        Property Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Property item);
    }
}
