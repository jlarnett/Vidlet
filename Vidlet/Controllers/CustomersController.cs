using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidlet.Models;
using System.Data.Entity;
using Vidlet.ViewModels;

namespace Vidlet.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        #region ApplicationDbContextMethods
        protected override void Dispose(bool disposing)
        {
            //Disposes of db context object. Overrides base displose method. 
            _context.Dispose();
        }
        #endregion

        #region Constructors
        public CustomersController()
        {
            //Creates new Application DBContext object.
            _context = new ApplicationDbContext();
        }
        #endregion

        // GET: Customers
        public ViewResult Index()
        {
            //Deferred execution. Querying happens when iterating over object. 
            //Adding .ToList Query Immediately. 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            //We get a list of membership types from database. E.G Context / Identity Model
            var membershipTypes = _context.MembershipTypes.ToList();

            //Initialize Viewmodel for New Customer View. 
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}