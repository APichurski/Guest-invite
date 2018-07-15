using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetList.Models
{
    public class GuestResponse
    {
        public Object Id { get; set; } 
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Please enter your choice")]
        public bool WillAttend { get; set; }

    }
}
