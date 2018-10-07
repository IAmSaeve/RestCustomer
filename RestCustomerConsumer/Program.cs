using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestCustomerConsumer.Model;

namespace RestCustomerConsumer
{
    class Program
    {
        private static readonly string CustomersUri = "https://restcustomerservice20181007065419.azurewebsites.net/api/Customers";

        static void Main(string[] args)
        {
            foreach (var c in GetCustomersAsync().Result)
            {
                System.Console.WriteLine(c);
            }
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
    }
}
