using BankManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Controllers
{
    public class TransactionController : Controller
    {
        private readonly MyDbContext _db;

        public TransactionController(MyDbContext db)
        {
            _db = db;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var data = _db.Transactions.ToList();
            return View(data);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = _db.Transactions.Single(x => x.Id == id);
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.Accounts = _db.Accounts.ToList();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public ActionResult Create(Transaction newTransaction)
        {
            try
            {
                _db.Transactions.Add(newTransaction);
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
            
            var data = _db.Transactions.Single(x => x.Id == id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(int id, Account editAccount)
        {
            try
            {
                var oldData = _db.Transactions.Where(x => x.Id == id).FirstOrDefault();
               
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
            var data = _db.Transactions.Single(x => x.Id == id);
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
                    var removeAccount = _db.Transactions.Single(x => x.Id == id);
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
