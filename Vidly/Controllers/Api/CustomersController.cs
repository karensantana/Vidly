using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController() //Initialized _context in the constructor
        {
            _context = new ApplicationDbContext();
        }
        //GET: /api/customers
        
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customer
       
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) //we return the Customer to the client :P 
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customer.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/"+customer.Id), customerDto);
        }

        //PUT /api/customer/id
        [HttpPut]
        public CustomerDto UpdateCustomer (int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map(customerDto, Customer); //This track changes in our object so we don't need to match each property.
            
            _context.SaveChanges(); //everytime you change something in _context or database you have to SaveChanges
            return customerDto;
        }

        //DELETE /api/customer/id 
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
