using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;

namespace POCData
{
    public class LoanViewModel 
        : ViewModelBase
    {
        public LoanViewModel() :base()
        {
            Loans = new List<Loan>();
            Entity = new Loan();
            Get();
        }

        protected override void Get()
        {
            base.Get();
            LoanUOW manager = new LoanUOW();
            Loans = manager.Get(SearchENtity);
        }
        protected override void Save()
        {
            LoanUOW mgr = new LoanUOW();
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
            base.Add();
        }
        protected override void Edit()
        {
            LoanUOW mgr = new LoanUOW();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
            base.Edit();
        }

        protected override void Delete()
        {
            LoanUOW manager = new LoanUOW();
            Loan bank = new Loan();
            bank.Id = Convert.ToInt32(EventArgument);
            manager.Delete(bank);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new Loan();
        }
        public Loan SearchENtity { get; set; }
        public Loan Entity { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
