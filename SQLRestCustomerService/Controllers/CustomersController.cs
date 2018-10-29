using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SQLRestCustomerService.Model;
using MySqlConnector;
using MySql.Data;

namespace SQLRestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        
        // GET: api/Customers
        [HttpGet]
        public List<Customer> Get()
        {
            return null;
        }

        // GET: api/Customers/1
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return null;
        }

        // POST api/Customers
        [HttpPost]
        public void InsertCustomer(Customer customer)
        {
            
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, [FromBody] Customer customer)
        {
            
        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            
        }
    }
}