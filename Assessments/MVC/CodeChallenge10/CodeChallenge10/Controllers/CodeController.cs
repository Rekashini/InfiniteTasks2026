using CodeChallenge10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge10.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        NorthWindEntities db = new NorthWindEntities();

        // Action Method 1
        public ActionResult GermanyCustomers()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();

            return View(customers);
        }

        // Action Method 2
        public ActionResult OrderCustomer()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            return View(customer);
        }
    }
    
}