using CRUDUsingAdoDotNet1.DAL;
using CRUDUsingAdoDotNet1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoDotNet1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeedal;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeedal = new EmployeeDAL(configuration);
        }


        // GET: EmployeeController
        public ActionResult List()
        {
            var model = employeedal.GetAllEmployee();
            return View(model);

        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeedal.GetEmployeeById(id);
            return View(employee);

        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int res = employeedal.AddEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {

            var employee = employeedal.GetEmployeeById(id);
            return View(employee);

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int res = employeedal.UpdateEmployee(emp);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: EmployeeController/Delete/5
        public ActionResult DeleteEmployee(int id)
        {
            var employee = employeedal.GetEmployeeById(id);
            return View(employee);

        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = employeedal.DeleteEmployee(id);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }

        }
    }
}
