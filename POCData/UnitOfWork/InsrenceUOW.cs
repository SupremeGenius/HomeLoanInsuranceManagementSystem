using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMSEntity;
using HLIMS.Entities;

namespace POCData
{
    public class InsurenceUOW : IActionManager,IInsurenceRepository
    {
        public List<KeyValuePair<string, string>> validationError
        {
            get;
            set;
        }
        public InsurenceUOW()
        {
            validationError = new List<KeyValuePair<string, string>>();
        }
        public bool Insert(BaseEntity entity)
        {
            Insurence insurence = entity as Insurence;
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
            Insurence insurence = entity as Insurence;
            validationError.Clear();
            if (string.IsNullOrEmpty(insurence.Name))
            {
                if (insurence.Name.ToLower() == insurence.Name)
                {
                    validationError.Add(new KeyValuePair<string, string>("InsurenceName", "Insurence Name must not be all in Lower case"));
                }
            }
            return (validationError.Count == 0);

        }
       /// <summary>
        /// Get
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<Insurence> Get(Insurence entity)
        {
            List<Insurence> returnData = new List<Insurence>();
            returnData = GetData();

            if (entity != null && !string.IsNullOrEmpty(entity.Name))
            {
                returnData = returnData.FindAll(p => p.Name.ToLower().StartsWith(
                    entity.Name.ToLower()));
            }
            return returnData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Insurence Get(int Id)
        {
            List<Insurence> list = new List<Insurence>();
            Insurence returnProduct = new Insurence();
            list = CreateMockData();
            returnProduct = list.Find(p => p.Id == Id);
            return returnProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Insurence entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnValue)
            {
                //Crete the update Code 
            }
            return returnValue;
        }

        public bool Delete(BaseEntity entity)
        {
            return true;
        }

        private List<Insurence> CreateMockData()
        {
            List<Insurence> ret = new List<Insurence>();
            ret.Add(new Insurence { Id = 1, Name = "ICICI Lomberd" });
            ret.Add(new Insurence { Id = 2, Name = "SBI Home" });
            return ret;
        }
        private List<Insurence> GetData()
        {
            List<Insurence> data = new List<Insurence>();
            using (var ctx = new HLIMSystemEntities())
            {
                //data = ctx.tblBanks.ToList<tblBank>();
                data = ctx.tblInsurences.Select(s => new Insurence()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList<Insurence>();
            }
            return data;
        }

    }
}
