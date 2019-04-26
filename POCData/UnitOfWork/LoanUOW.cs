using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMSEntity;

using HLIMS.Entities;

namespace POCData
{
    public class LoanUOW : 
                IActionManager, ILoanRepository
    {
        public List<KeyValuePair<string, string>> validationError
        {
            get;
            set;
        }
        public LoanUOW()
        {
            validationError = new List<KeyValuePair<string, string>>();
        }

        public bool Validate(BaseEntity entity)
        {
            Loan property = entity as Loan;
            validationError.Clear();
            return (validationError.Count == 0);
        }

        public List<Loan> Get(Loan entity)
        {
            List<Loan> returnData = new List<Loan>();
            returnData = getData();

            //if (entity != null && !string.IsNullOrEmpty(entity.OurginalAmount))
            //{
            //    returnData = returnData.FindAll(p => p.Address.ToLower().StartsWith(
            //        entity.Address.ToLower()));
            //}
            return returnData;
        }

        private List<Loan> getData()
        {
            List<Loan> data = new List<Loan>();
            using (var ctx = new HLIMSystemEntities())
            {
                data = ctx.tblLoans.Select(s => new Loan()
                {
                    Id = s.Id,
                    OurginalAmount= s.OriginalAmount,
                    RemainingAmount = s.ReminingAmount,
                    RemainingTenure =s.ReminingTenure,
                    Tenure = s.OriginalTenure,
                    Borrwoer =new Borrower() {
                        Id = s.tblBorrower.Id,
                        FirstName = s.tblBorrower.FirstName,
                        MiddleName = s.tblBorrower.MiddleName,
                        LastName = s.tblBorrower.LastName,
                        Email = s.tblBorrower.Email,
                        Gender = s.tblBorrower.Gender,
                        MailingAddress = s.tblBorrower.MailingAddress,
                        Phone = s.tblBorrower.Phone,
                        StreetAddress = s.tblBorrower.StreetAddress
                    }
                }).ToList<Loan>();
            }
            return data;
        }

        public Loan Get(int Id)
        {
            List<Loan> list = new List<Loan>();
            Loan returnProduct = new Loan();
            list = getData();
            returnProduct = list.Find(p => p.Id == Id);
            return returnProduct;
        }

        public bool Insert(BaseEntity entity)
        {
            Loan property = entity as Loan;
            bool ret = false;
            ret = Validate(property);
            if (ret)
            {
                //Create Insert Statement
            }
            return ret;

        }

        public bool Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Loan entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnValue)
            {
                //Crete the update Code 
            }
            return returnValue;
        }

    }
}
