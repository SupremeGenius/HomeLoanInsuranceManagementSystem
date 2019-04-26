using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;
using HLIMS.Entities;

namespace POCData
{
    public class BorrowerViewModel :ViewModelBase
    {
        public BorrowerViewModel():base()
        {
            Banks = new List<Borrower>();
            Entity = new Borrower();
            Get();
        }

        protected override void Get()
        {
            base.Get();
            BorrowerUOW manager = new BorrowerUOW();
            Banks = manager.Get(SearchENtity);
        }
        protected override void Save()
        {
            BorrowerUOW mgr = new BorrowerUOW();
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
            Entity = new Borrower()
            {
                FirstName = "Enter Name",
            };
            base.Add();
        }
        protected override void Edit()
        {
            BorrowerUOW mgr = new BorrowerUOW();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode();
            base.Edit();
        }


        protected override void Delete()
        {
            BorrowerUOW manager = new BorrowerUOW();
            Borrower bank = new Borrower();
            bank.Id = Convert.ToInt32(EventArgument);
            manager.Delete(bank);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new Borrower();
        }
        public Borrower SearchENtity { get; set; }
        public Borrower Entity { get; set; }
        public List<Borrower> Banks { get; set; }
    }
}
