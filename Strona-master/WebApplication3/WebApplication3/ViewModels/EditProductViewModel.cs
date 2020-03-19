using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class EditProductViewModel
    {
        public Podzespol Podzespol { get; set; }
        public IEnumerable<podzespoly> podzespoly { get; set; }
        public bool? ConfirmSuccess { get; set; }

    }
}