using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeChallenge11_Ques2.Controllers
{
    public class CustomersController : ApiController
    {
        NorthWindEntities1 db = new NorthWindEntities1();

        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var result = db.GetCustomersByCountry(country).ToList();
            return Ok(result);
        }
    }
}
