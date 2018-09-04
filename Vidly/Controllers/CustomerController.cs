using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer customer) //Here MVC is binding model View Model with Customer Model
        {
            if (!ModelState.IsValid) //We use Model State property to get access to validation data.
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                // Mapper.Map(customer, customerInDb);
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsletter = customer.IsSubsribedToNewsletter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Details (int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Edit (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
            

        }
        public ActionResult Index()
        {
           
           
           
            return View();
        }
    }
}