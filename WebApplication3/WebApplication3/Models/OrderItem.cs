using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }

        public int PodzespolId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrize { get; set; }
        public virtual Podzespol podzespol { get; set; }
        public virtual Order Order { get; set; }

    }
}