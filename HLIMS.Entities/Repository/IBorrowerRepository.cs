using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;

namespace HLIMS.Entities
{
    public interface IBorrowerRepository
    {
        List<Borrower> Get(Borrower entity);
        Borrower Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Borrower item);
    }
}
