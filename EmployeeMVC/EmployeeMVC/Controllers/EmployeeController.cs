using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeData objemployee = new EmployeeData();

        public IActionResult index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.GetAllEmployees().ToList();

            return View(lstEmployee);
        }


        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddEmployee(employee);
                return RedirectToAction("index");
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(int id, [Bind] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objemployee.UpdateEmployee(employee);
                return RedirectToAction("index");
            }
            return View(employee);

        }

        [HttpGet]
        public IActionResult DetailsEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objemployee.DeleteEmployee(id);
            return RedirectToAction("index");
        }
    }
}
