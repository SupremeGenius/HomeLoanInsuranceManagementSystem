using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMSEntity;
using HLIMS.Entities;

namespace POCData
{
    public class BorrowerUOW : IActionManager, IBorrowerRepository
    {
        public List<KeyValuePair<string, string>> validationError
        {
            get;
            set;
        }
        public BorrowerUOW()
        {
            validationError = new List<KeyValuePair<string, string>>();
        }
        public bool Insert(BaseEntity entity)
        {
            Borrower insurence = entity as Borrower;
            bool ret = false;
            ret = Validate(insurence);
            if (ret)
            {
                //Create Insert Statement
            }
            return ret;
        }
        public bool Validate(BaseEntity entity)
        {
            Borrower borrower = entity as Borrower;
            validationError.Clear();
            if (string.IsNullOrEmpty(borrower.FirstName))
            {
                if (borrower.FirstName.ToLower() == borrower.FirstName)
                {
                    validationError.Add(new KeyValuePair<string, string>("BorrowerName", "Borrower Name must not be all in Lower case"));
                }
            }
            return (validationError.Count == 0);

        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<Borrower> Get(Borrower entity)
        {
            List<Borrower> returnData = new List<Borrower>();
            returnData = GetData();

            if (entity != null && !string.IsNullOrEmpty(entity.FirstName))
            {
                returnData = returnData.FindAll(p => p.FirstName.ToLower().StartsWith(
                    entity.FirstName.ToLower()));
            }
            return returnData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Borrower Get(int productId)
        {
            List<Borrower> list = new List<Borrower>();
            Borrower returnProduct = new Borrower();
            list = GetData();
            returnProduct = list.Find(p => p.Id == productId);
            return returnProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Borrower entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnValue)
            {
                //Crete the update Code 
            }
            return returnValue;
        }


        private List<Borrower> CreateMockData()
        {
            List<Borrower> ret = new List<Borrower>();
            ret.Add(new Borrower { Id = 1, FirstName= "Sunirmal", LastName="Sikder" });
            ret.Add(new Borrower { Id = 2, FirstName = "Sunirmal", LastName = "Sikder" });
            return ret;

        }
        private List<Borrower> GetData()
        {
            List<Borrower> data = new List<Borrower>();
            using (var ctx = new HLIMSystemEntities())
            {
                data = ctx.tblBorrowers.Select(s => new Borrower()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    MiddleName= s.MiddleName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Gender= s.Gender,
                    MailingAddress= s.MailingAddress,
                    Phone= s.Phone,
                    StreetAddress = s.StreetAddress
                }).ToList<Borrower>();
            }
            return data;
        }
        public bool Delete(BaseEntity entity)
        {
            return true;
        }
    }
}
