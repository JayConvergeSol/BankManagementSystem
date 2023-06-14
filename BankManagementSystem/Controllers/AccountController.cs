using BankManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _db;

        public AccountController(MyDbContext db)
        {
            _db = db;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var data = _db.Accounts.Include("Customer").ToList();
            return View(data);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = _db.Accounts.Single(x => x.Id == id);
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.Customer = _db.Customers.ToList();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public ActionResult Create(Account newAccount)
        {
            try
            {
                _db.Accounts.Add(newAccount);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }

        }

        
        public ActionResult Edit(int id)
        {
            ViewBag.Customer = _db.Customers.ToList();
            var data = _db.Accounts.Single(x => x.Id == id);
            return View(data);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Account editAccount)
        {
            try
            {
                var oldData = _db.Accounts.Where(x => x.Id == id).FirstOrDefault();
                oldData.AccountType = editAccount.AccountType;
                oldData.Balance = editAccount.Balance;
                oldData.AccountOpenDate = editAccount.AccountOpenDate;
                oldData.CustomerId = editAccount.CustomerId;
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
            var data = _db.Accounts.Single(x => x.Id == id);
            
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string response = "")
        {
            try
            {
                if (response == "yes")
                {
                    var removeAccount = _db.Accounts.Single(x => x.Id == id);
                    _db.Remove(removeAccount);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }

        }
        public ActionResult Error()
        {
            return View("Error");
        }

    }
}
