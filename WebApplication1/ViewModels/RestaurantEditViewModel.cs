using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Display(Name = "Név")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Tipus")]
        [Required]
        public CusineType CusineType { get; set; }

        [Display(Name = "Weboldal")]
        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}
