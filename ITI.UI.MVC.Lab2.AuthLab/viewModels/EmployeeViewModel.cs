using ITI.UI.MVC.Lab2.AuthLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.Lab2.AuthLab.viewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Department> Departments { get; set; }

        public List<Employee> Employees { get; set; }


    }
}