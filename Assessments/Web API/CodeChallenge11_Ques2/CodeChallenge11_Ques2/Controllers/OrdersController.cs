using CodeChallenge11_Ques2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class OrdersController : ApiController
{
    private NorthWindEntities1 db = new NorthWindEntities1();

    // 1. Orders of Buchanan Steven (EmployeeId = 5)
    [HttpGet]
    [Route("api/orders/buchanan")]
    public IHttpActionResult GetBuchananOrders()
    {
        var orders = db.Orders
                       .Where(o => o.EmployeeID == 5)
                       .Select(o => new
                       {
                           o.OrderID,
                           o.OrderDate,
                           o.CustomerID,
                           o.Freight
                       })
                       .ToList();

        return Ok(orders);
    }
}