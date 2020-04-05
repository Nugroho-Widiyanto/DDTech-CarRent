using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Web.ViewModels
{
    public class RentCalculatorViewModel
    {
        [Required]
        [Display(Name = "Price per Day")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Duration in Days")]
        public byte Duration { get; set; }

        [Required]
        [Display(Name = "Number of Cars")]
        public byte Cars { get; set; }

        [Required]
        [Display(Name = "Manufacturing Year")]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);

        [Display(Name = "Total Discount (%)")]
        public double Discount { get; set; }
    }
}
