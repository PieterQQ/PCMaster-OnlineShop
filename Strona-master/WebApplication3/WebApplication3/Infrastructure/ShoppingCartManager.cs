using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Infrastructure
{
    public class ShoppingCartManager
    {
        private StoreContext db;
        private ISessionManager session;

        public const string CartSessionKey = "CartData";
        public ShoppingCartManager(ISessionManager session,StoreContext db)
        {
            this.session = session;
            this.db = db;
        }
        public void AddToCart(int parametrid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Podzespol.PodzespolId == parametrid);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                // Find album and add it to cart
                var PodzespolToAdd = db.Podzespol.Where(a => a.PodzespolId == parametrid).SingleOrDefault();
                if (PodzespolToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Podzespol = PodzespolToAdd,
                        Quantity = 1,
                        TotalPrice = PodzespolToAdd.Price
                    };

                    cart.Add(newCartItem);
                }
            }

            session.Set(CartSessionKey, cart);
        }

        public int RemoveFromCart(int Podzespolid)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Podzespol.PodzespolId == Podzespolid);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                    cart.Remove(cartItem);
            }

            // Return count of removed item currently inside cart
            return 0;
        }


        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }

            return cart;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(c => (c.Quantity * c.Podzespol.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(c => c.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
          newOrder.UserId = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    PodzespolId = cartItem.Podzespol.PodzespolId,
                    Quantity = cartItem.Quantity,
                    UnitPrize = cartItem.Podzespol.Price
                };

                cartTotal += (cartItem.Quantity * cartItem.Podzespol.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrize = cartTotal;

            this.db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }

    }
}
