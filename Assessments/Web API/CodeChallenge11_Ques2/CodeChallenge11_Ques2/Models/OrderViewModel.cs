using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge11_Ques2.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerID { get; set; }
        public decimal? Freight { get; set; }
    }
}