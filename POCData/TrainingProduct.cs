using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace POCData
{
    public class TrainingProduct
    {
        public int Productid { get; set; }
        [Required(ErrorMessage = "Product Name is Required..")]
        [Display(Description = "Product Name")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Product Name Must be greated than  {2} Characteres and Less than {1}")]
        public string ProductName { get; set; }
       // [Range(typeof(DateTime), "1/1/2000", "12/21/2020", ErrorMessage = "Date must be between")]
       //  [Display(Description ="Introduction Date")]
        public DateTime IntroductionDate { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
    }
}
