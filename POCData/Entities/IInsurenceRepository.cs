using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;
namespace POCData
{
    public interface IInsurenceRepository
    {
        List<Insurence> Get(Insurence entity);
        Insurence Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Insurence item);
    }
}
