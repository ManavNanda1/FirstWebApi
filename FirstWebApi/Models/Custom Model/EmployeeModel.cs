using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models.Custom_Model
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string CountryName { get; set; }
    }
}