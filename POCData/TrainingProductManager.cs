using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCData
{
    public class TrainingProductManager
    {
        public List<KeyValuePair<string, string>> validationError { get;set; }
        public TrainingProductManager()
        {
            validationError = new List<KeyValuePair<string, string>>();

        }
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Validate(TrainingProduct entity )
        {
            validationError.Clear();
            //string.IsNullOrWhiteSpace
            if (string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower()== entity.ProductName)
                {
                    validationError.Add(new KeyValuePair<string, string>("ProductName","Product Name must not be all in Lower case"));
                }
            }
            return (validationError.Count ==0);
        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(TrainingProduct entity)
        {
            bool ret=false;
            ret = Validate(entity);
            if (ret)
            {
                //Create Insert Statement
            }
            return ret;

        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret = CreateMockData();

            if (entity!= null && !string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public TrainingProduct Get(int productId)
        {
            List<TrainingProduct> list = new List<TrainingProduct>();
            TrainingProduct returnProduct = new TrainingProduct();
            list = CreateMockData();
            returnProduct = list.Find(p => p.Productid == productId);
            return returnProduct;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TrainingProduct entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnValue)
            {
                //Crete the update Code 
            }
            return returnValue;
        }

        public bool Delete(TrainingProduct entity)
        {

            return true;
        }

        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret.Add(new TrainingProduct { Productid = 1, ProductName = "Extending Bootstrap with CSS JS", IntroductionDate = Convert.ToDateTime("01/01/2019"), Price = 100, Url = "www.google.com" });
            ret.Add(new TrainingProduct { Productid = 2, ProductName = "Programming with Entity Framework", IntroductionDate = Convert.ToDateTime("01/01/2019"), Price = 100, Url = "www.google1.com" });
            ret.Add(new TrainingProduct { Productid = 3, ProductName = "Learn Communication Skills", IntroductionDate = Convert.ToDateTime("01/01/2019"), Price = 100, Url = "www.google2.com" });
            ret.Add(new TrainingProduct { Productid = 4, ProductName = "Working in Jave", IntroductionDate = Convert.ToDateTime("01/01/2019"), Price = 100, Url = "www.google3.com" });
            ret.Add(new TrainingProduct { Productid = 5, ProductName = "Thinking in c#", IntroductionDate = Convert.ToDateTime("01/01/2019"), Price = 100, Url = "www.google4.com" });
            return ret;
        }
    }
}
