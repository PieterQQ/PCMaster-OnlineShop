using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Podzespol> Bestsellers { get; set; }
        public IEnumerable<Podzespol> NewArrivals { get; set; }
        public IEnumerable<podzespoly> Podzespoly { get; set; }
    }
}