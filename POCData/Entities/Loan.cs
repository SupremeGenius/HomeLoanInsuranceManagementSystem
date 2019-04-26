using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;

namespace POCData
{
    public interface ILoanRepository
    {
        List<Loan> Get(Loan entity);
        Loan Get(int productId);
        bool Insert(BaseEntity entity);
        bool Delete(BaseEntity entity);
        bool Update(Loan item);
    }

    public class Loan
                :BaseEntity
    {
        public decimal? OurginalAmount { get; set; }
        public decimal? Tenure { get; set; }
        public decimal? RemainingAmount { get; set; }
        public decimal? RemainingTenure { get; set; }
        public Borrower Borrwoer { get; set; }
    }
}
