using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class podzespoly
    {
        public int PodzespolyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Podzespol> Podzespoly1 { get; set; }
    }

}