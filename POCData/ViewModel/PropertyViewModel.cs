using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCCommon;
using HLIMS.Entities;

namespace POCData
{
    public class PropertyViewModel : ViewModelBase
    {
        public PropertyViewModel():base()
        {
            Properties = new List<Property>();
            Entity = new Property();
            Get();
        }

        protected override void Get()
        {
            base.Get();
            PropertyUOW manager = new PropertyUOW();
            Properties = manager.Get(SearchENtity);
        }
        protected override void Save()
        {
            PropertyUOW mgr = new PropertyUOW();
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
            Entity = new Property()
            {
                Address = "Enter Address",
            };
            base.Add();
        }
        protected override void Edit()
        {
            PropertyUOW mgr = new PropertyUOW();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
            base.Edit();
        }

        protected override void Delete()
        {
            PropertyUOW manager = new PropertyUOW();
            Property bank = new Property();
            bank.Id = Convert.ToInt32(EventArgument);
            manager.Delete(bank);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchENtity = new Property();
        }
        public Property SearchENtity { get; set; }
        public Property Entity { get; set; }
        public List<Property> Properties { get; set; }
    }
}
