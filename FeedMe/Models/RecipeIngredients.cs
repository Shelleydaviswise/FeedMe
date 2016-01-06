using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class Ingredients
    {
        public string Food { get; set; }
        public string Measure { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}