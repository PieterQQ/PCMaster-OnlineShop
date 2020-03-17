using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CartItem
    {
        public Podzespol Podzespol { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}