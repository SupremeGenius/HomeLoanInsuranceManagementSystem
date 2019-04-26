using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;

namespace POCData
{
    public class TrainingProductViewModel : ViewModelBase

    {
        public TrainingProductViewModel():base()
        {
            Products = new List<TrainingProduct>();
            Entity = new TrainingProduct();
            Get();
        }
        //public void Get()
        protected override void Get()
        {
            base.Get();
            TrainingProductManager manager = new TrainingProductManager();
            Products = manager.Get(SearchENtity);
        }
        public TrainingProduct SearchENtity { get; set; }
        public TrainingProduct Entity { get; set; }
        public List<TrainingProduct> Products { get; set; }

        /// <summary>
        /// save
        /// </summary>
        protected override void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            if (IsValid)
            {
                if (Mode == "Add")
                {
                    //Add Data to DB
                    mgr.Insert(Entity);
                }
                else
                {
                    mgr.Update(Entity);
                }
                ValidationErrors = mgr.validationError;
                
            }
            base.Save();
        }
       
        protected override void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Url = "http://",
                Price = 0
            };
            base.Add();
        }
        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode();
            base.Edit();
        }
        protected override void Delete()
        {
            TrainingProductManager manager = new TrainingProductManager();
            TrainingProduct product = new TrainingProduct();
            product.Productid = Convert.ToInt32(EventArgument);
            manager.Delete(product);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new TrainingProduct();
        }
       
    }
}
