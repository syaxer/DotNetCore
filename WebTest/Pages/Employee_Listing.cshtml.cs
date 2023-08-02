using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class Employee_ListingModel : PageModel
    {
        public List<Employee> employeeList = new List<Employee>();
        public void OnGet()
        {
            Employee employee = new Employee();

            employeeList = employee.GetRec();
        }
    }
}
