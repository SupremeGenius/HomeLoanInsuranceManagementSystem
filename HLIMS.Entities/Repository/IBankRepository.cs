using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLIMS.Entities
{
    public interface IBankRepository
    {
        List<Bank> Get(Bank entity);
        Bank Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Bank item);
    }
}
