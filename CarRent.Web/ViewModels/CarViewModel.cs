using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Web.ViewModels
{
    public class CarViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Display(Name = "License Plate Number")]
        [StringLength(8, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Plate { get; set; }

        [Required]
        [Display(Name = "Brand Name")]
        [StringLength(64, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model Name")]
        [StringLength(64, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Model { get; set; }

        [Required]
        [Range(2, 8, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public byte Capacity { get; set; } = 5;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [Display(Name = "Manufacturing Year")]
        public DateTime Year { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Car" : "New Car";
            }
        }
    }
}
