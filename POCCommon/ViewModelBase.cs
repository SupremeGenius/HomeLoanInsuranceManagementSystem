using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCCommon
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            init();

        }
        protected virtual void Get() {}
        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }
            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    addMode();
                }
                if (Mode == "Edit")
                {
                    EditMode();
                }
            }
        }
        protected virtual void Add() { }
        protected virtual void Edit() { }
        protected virtual void Delete() { }
        protected virtual void ResetSearch() { }
        #region Public Methods
        protected virtual void init()
        {
            EventCommand = "list";
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();
            listMode();
           
        }
        protected virtual void listMode()
        {
            IsListAreaVisible = true;
            ISearchAreaVisible = true;
            IsDetailAreaVisible = false;
            IsValid = true;
            Mode = "List";

        }
        protected virtual void cancelMode()
        {
            IsListAreaVisible = true;
            ISearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }
        protected virtual void addMode()
        {
            IsListAreaVisible = false;
            ISearchAreaVisible = false;
            IsDetailAreaVisible = true;
            Mode = "Add";
        }
        protected virtual void EditMode()
        {
            IsListAreaVisible = false;
            ISearchAreaVisible = false;
            IsDetailAreaVisible = true;
            Mode = "Edit";
        }
        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    listMode();
                    ValidationErrors = new List<KeyValuePair<string, string>>();
                    Get();
                    break;
                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
                case "add":
                    addMode();
                    Add();
                    break;
                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;
                case "cancel":
                    cancelMode();
                    ResetSearch();
                    Get();
                    break;
                case "edit":
                    Edit();
                    break;
                case "delete":
                    ResetSearch();
                    Delete();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Public Properties
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool ISearchAreaVisible { get; set; }
        #endregion
    }
}
