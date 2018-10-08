using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestCustomerConsumer.Model;

namespace RestCustomerConsumer
{
    class Program
    {
        // Azure or localhost
        // private static readonly string CustomersUri = "https://restcustomerservice20181007065419.azurewebsites.net/api/Customers";
        private static readonly string CustomersUri = "http://localhost:5000/api/Customers";

        static void Main(string[] args)
        {
            // Add customer
            // PostCustomersAsync(new Customer(3, "D", "D", 2580));

            // Delete customer
            // DeleteCustomers(2);

            // Put customer
            PutCustomersAsync(2, new Customer(2, "G", "R", 1852));

            // Get list of customers
            // foreach (var c in GetCustomersAsync().Result)
            // {
            //     System.Console.WriteLine(c);
            // }
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public static async void PostCustomersAsync(Customer cust)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(cust);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(CustomersUri, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                } else { 
                    Console.Write("Error");
                }
            }
        }

        public static void DeleteCustomers(int id)
        {
            using (HttpClient client = new HttpClient())
            {   
                var response = client.DeleteAsync(CustomersUri + "/" + id).Result;    
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                } else { 
                    Console.Write("Error");
                }
            }
        }

        
        public static void PutCustomersAsync(int id, Customer cust)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(cust);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = client.PutAsync(CustomersUri + "/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                } else { 
                    Console.Write("Error");
                }
            }
        }
    }
}
