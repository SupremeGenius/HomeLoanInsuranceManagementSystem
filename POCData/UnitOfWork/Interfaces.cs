using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMS.Entities;
namespace POCData
{
    public interface IActionManager
    {
        bool Validate(BaseEntity entity);
       // bool Insert(BaseEntity entity);
      //  bool Delete(BaseEntity entity);
        List<KeyValuePair<string, string>> validationError { get; set; }
    }

}
