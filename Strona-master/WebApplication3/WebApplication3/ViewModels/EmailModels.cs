using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public string FullAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CovertPath { get; set; }
    }
    public class ShippedConfirmationEmail:Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public string FullAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CovertPath { get; set; }

    }
}