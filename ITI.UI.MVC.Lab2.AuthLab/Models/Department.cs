using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.Lab2.AuthLab.Models
{

    [Table("Department")]
    public class Department
    {
        public int id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}