using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestCustomerService.Model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(0, "S", "P", 4567),
            new Customer(1, "A", "B", 1234),
            new Customer(2, "C", "D", 6543)
        };
        
        public static int nextId = 0;
        
        // GET: api/Customers
        [HttpGet]
        public List<Customer> Get()
        {
            return cList;
        }

        // GET: api/Customers/1
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return cList.Find(c => (c.Id == id));
        }

        // POST api/Customers
        [HttpPost]
        public void InsertCustomer(Customer customer)
        {
            cList.Add(customer);
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, [FromBody] Customer customer)
        {
            var cust = cList.Find(c => (c.Id == id));

            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.Year = customer.Year;
        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            cList.Remove(cList.Find(c => c.Id == id));
        }
    }
}