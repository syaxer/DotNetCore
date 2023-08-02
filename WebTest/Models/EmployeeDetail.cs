using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class EmployeeDetail
    {
        [BindProperty]
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }

        [BindProperty]
        [Display(Name = "Employee Name:")]
        public string EmpName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert Email!")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert Mobile No!")]
        [Display(Name = "Mobile No:")]
        public string MobileNo { get; set; }
    }
}
