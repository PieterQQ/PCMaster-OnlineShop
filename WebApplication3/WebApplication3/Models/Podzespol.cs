using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Podzespol
    {
        public int PodzespolId { get; set; }
        public int PodzespolyId { get; set; }
        public string NazwaPodzespolu { get; set; }
        public string Producent { get; set; }
        public DateTime DateAdded { get; set; }
        public string ConvertFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsHidden { get; set; }
      
        public virtual podzespoly podzespoly { get; set; }
    }
}