using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
     //   public string ApplicationUser_Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required(ErrorMessage ="Wprowadź imię")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Wprowadź adres")]
        [StringLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage ="Wprowadź kod pocztowy i miasto")]
        [StringLength(100)]
        public string CodeAndCity { get; set; }
        [Required(ErrorMessage = "Wprowadź numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Wprowadź adres e-mail")]
        [EmailAddress(ErrorMessage ="Niepoprawny adres e-mail")]
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrize { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
    public enum OrderState
    {
        [Display (Name="Nowe")]
        New,
        [Display(Name = "Wysłane")]
        Shipped
    }
}