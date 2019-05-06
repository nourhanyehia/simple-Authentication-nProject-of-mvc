using ITI.UI.MVC.Lab2.AuthLab.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.Lab2.AuthLab.Models
{

    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int FK_DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}