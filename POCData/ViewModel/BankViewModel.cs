using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;

using HLIMS.Entities;

namespace POCData
{
    public class BankViewModel :
                ViewModelBase
    {
        public BankViewModel():base()
        {
            Banks = new List<Bank>();
            Entity = new Bank();
            Get();
        }

        protected override void Get()
        {
            base.Get();
            BankUOW manager = new BankUOW();
            Banks = manager.Get(SearchENtity);
        }
        protected override void Save()
        {
            BankUOW mgr = new BankUOW();
            if (IsValid)
            {
                if (Mode == "Add")
                {
                    //Add Data to DB
                    mgr.Insert(Entity);
                }
                else
                {
                    Bank bank = new Bank();
                    bank.Name = Entity.Name;
                    bank.Id = Convert.ToInt32(EventArgument);
                    mgr.Update(Entity);
                }
                ValidationErrors = mgr.validationError;

            }
            base.Save();
        }
        protected override void Add()
        {
            IsValid = true;
            Entity = new Bank()
            {
                Name = "Enter Bank Name",
            };
            base.Add();
        }
        protected override void Edit()
        {
            BankUOW mgr = new BankUOW();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode();
            base.Edit();
        }
        protected override void Delete()
        {
            BankUOW manager = new BankUOW();
            Bank bank = new Bank();
            bank.Id= Convert.ToInt32(EventArgument);
            manager.Delete(bank);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new Bank();
        }
        public Bank SearchENtity { get; set; }
        public Bank Entity { get; set; }
        public List<Bank> Banks { get; set; }

    }
}
