using BankManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyDbContext _db;

        public CustomerController(MyDbContext db)
        {
            _db = db;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var data = _db.Customers.ToList();
            return View(data);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = _db.Customers.Single(x => x.Id == id);
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public ActionResult Create(Customer newCustomer)
        {
            try
            {
                _db.Customers.Add(newCustomer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View("Error");
            }
           
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _db.Customers.Single(x => x.Id == id);
            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Customer editCustomer)
        {
            try
            {
                var oldData = _db.Customers.Where(x => x.Id == id).FirstOrDefault();
                oldData.FirstName = editCustomer.FirstName;
                oldData.LastName = editCustomer.LastName;
                oldData.DateOfBirth = editCustomer.DateOfBirth;
                oldData.Gender = editCustomer.Gender;
                oldData.Address = editCustomer.Address;
                oldData.PhoneNumber = editCustomer.PhoneNumber;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View("Error");
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _db.Customers.Single(x => x.Id == id);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string response="")
        {
            try
            {
                if (response == "yes")
                {
                    var removeCustomer = _db.Customers.Single(x => x.Id == id);
                    _db.Remove(removeCustomer);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch 
            {
                return View("Error");
            }
            
        }

    }
}
