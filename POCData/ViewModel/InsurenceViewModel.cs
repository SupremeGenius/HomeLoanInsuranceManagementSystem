using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;

namespace POCData
{
    public class InsurenceViewModel : ViewModelBase
    {
        public InsurenceViewModel():base()
        {
            Insurences = new List<Insurence>();
            Entity = new Insurence();
            Get();
        }

        protected override void Get()
        {
            base.Get();
            InsurenceUOW manager = new InsurenceUOW();
            Insurences = manager.Get(SearchENtity);
        }
        protected override void Save()
        {
            InsurenceUOW mgr = new InsurenceUOW();
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
            Entity = new Insurence()
            {
                Name = "Enter Name",
            };
            base.Add();
        }
        protected override void Edit()
        {
            InsurenceUOW mgr = new InsurenceUOW();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
            base.Edit();
        }

        protected override void Delete()
        {
            InsurenceUOW manager = new InsurenceUOW();
            Insurence bank = new Insurence();
            bank.Id = Convert.ToInt32(EventArgument);
            manager.Delete(bank);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new Insurence();
        }
        public Insurence SearchENtity { get; set; }
        public Insurence Entity { get; set; }
        public List<Insurence> Insurences { get; set; }
    }
}
