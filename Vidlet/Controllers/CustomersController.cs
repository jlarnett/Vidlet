using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlet.Models;

namespace Vidlet.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            //Creates new Application DBContext object.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //Disposes of db context object. Overrides base displose method. 
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            //Deferred execution. Querying happens when iterating over object. 
            //Adding .ToList Query Immediately. 
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //Executed immediately. 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}