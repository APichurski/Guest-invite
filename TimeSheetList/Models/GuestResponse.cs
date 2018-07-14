using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetList.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]
        private string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        private int Phone { get; set; }
        [Required(ErrorMessage = "Please enter your choice")]
        private bool WillAttend { get; set; }

    }
}
