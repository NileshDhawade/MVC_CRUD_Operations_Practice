using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_Operation_Practice.Entities;
using MVC_CRUD_Operation_Practice.Models;
using System;

namespace MVC_CRUD_Operation_Practice.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL context = new EmployeeDAL();
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }
        // GET: EmployeeController
        //public ActionResult Index()
        //{
         //   var employee= context.GetAllEmployee();
          //  return View(employee);
        //}

        // GET: EmployeeController/Details/5
        public ActionResult EmployeeDetails()
        {
            //Employee emp = context.GetEmployeeByid(EmployeeId);
            ViewBag.employeeList = context.GetAllEmployee();
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection )
        {
            Employee emp = new Employee();
            emp.EmployeeName = collection["EmployeeName"];
            emp.EmployeeSalary = Convert.ToDecimal(collection["EmployeeSalary"]);
            emp.EmployeeAddress = collection["EmployeeAddress"];
            emp.EmployeeRole = collection["EmployeeRole"];
            emp.EmployeeCity = collection["EmployeeCity"];
            int res = context.Save(emp);
            if (res == 1)
                return RedirectToAction("EmployeeDetails");

            return View();

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int EmployeeId)
        {
            Employee emp = context.GetEmployeeByid(EmployeeId);
            ViewBag.EmployeeName = emp.EmployeeName;
            ViewBag.EmployeeSalary = emp.EmployeeSalary;
            ViewBag.EmployeeAddress = emp.EmployeeAddress;
            ViewBag.EmployeeRole= emp.EmployeeRole;
            ViewBag.EmployeeCity= emp.EmployeeCity;
            ViewBag.EmployeeId = emp.EmployeeId;
           
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( IFormCollection collection)
        {
            Employee emp = new Employee();
            emp.EmployeeName = collection["EmployeeName"];
            emp.EmployeeSalary = Convert.ToDecimal(collection["EmployeeSalary"]);
            emp.EmployeeAddress = collection["EmployeeAddress"];
            emp.EmployeeRole = collection["EmployeeRole"];
            emp.EmployeeCity = collection["EmployeeCity"];
            emp.EmployeeId = Convert.ToInt32(collection["EmployeeId"]);
            int res = context.Upate(emp);
            if (res == 1)
                return RedirectToAction("EmployeeDetails");

            return View();

        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int EmployeeId)
        {
            Employee emp = context.GetEmployeeByid(EmployeeId);
            ViewBag.EmployeeName = emp.EmployeeName;
            ViewBag.EmployeeSalary = emp.EmployeeSalary;
            ViewBag.EmployeeAddress = emp.EmployeeAddress;
            ViewBag.EmployeeRole = emp.EmployeeRole;
            ViewBag.EmployeeCity = emp.EmployeeCity;
            ViewBag.EmployeeId = emp.EmployeeId;
            return View();
           
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName ("Delete")]
        public ActionResult DeleteConform(int EmployeeId)
        {
            int res = context.Delete(EmployeeId);
            if (res == 1)
                return RedirectToAction("EmployeeDetails");

            return View();

        }
    }
}
