using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CustomerOrderAPI.Controllers
{
        public class DataController : ApiController
        {
            private readonly NorthwindEntities _context = new NorthwindEntities();

        [HttpGet]
        [Route("api/orders/empid")]
        public IHttpActionResult GetOrdersByEmployee(int employeeId)
        {

            var orders = _context.Orders
                       .Where(o => o.EmployeeID == employeeId)
                       .Select(o => new
                       {
                           o.OrderID,
                           o.OrderDate,
                           o.CustomerID,
                           CompanyName = o.Customer.CompanyName,
                           ContactName = o.Customer.ContactName,
                           EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName
                       })
                       .ToList();

            return Ok(orders);

        }

        [HttpGet]
            [Route("api/customers/bycountry/{country}")]
            public IHttpActionResult GetCustomersByCountry(string country)
            {
                var customers = _context.GetCustomersByCountry(country).ToList();
                return Ok(customers);
            }
        }
}