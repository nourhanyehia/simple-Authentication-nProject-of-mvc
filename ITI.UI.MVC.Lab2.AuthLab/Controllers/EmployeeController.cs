using ITI.UI.MVC.Lab2.AuthLab.Models;
using ITI.UI.MVC.Lab2.AuthLab.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.Lab2.AuthLab.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee

        static ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.action = "Add";
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Employees = context.Employees.ToList();
            empVm.Departments = context.Departments.ToList();
            return View(empVm);
        }

     

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult Add(EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(empVM.Employee);
                context.SaveChanges();
                return PartialView("_PartialEmployeeRow", empVM.Employee);
            }
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Departments = context.Departments.ToList();
            return View("AddEdit", empVm);
        }


        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Employee emp = context.Employees.FirstOrDefault(e => e.id == id);
            if (emp != null)
            {
                return View("AddEdit", emp);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                var oldemp = context.Employees.FirstOrDefault(e => e.id == empVM.Employee.id);
                if (oldemp != null)
                {
                    oldemp.Name = empVM.Employee.Name;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            return View("AddEdit", empVM);
        }


        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id)
        {
            Employee result = context.Employees.FirstOrDefault(e => e.id == id);
            if (result != null)
            {
                context.Employees.Remove(result);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
