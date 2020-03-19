using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;
using WebApplication3.Infrastructure;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext storeContext = new StoreContext();

        private ApplicationUserManager _userManager;
        // GET: Cart
        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, storeContext);

        }
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();
            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };
            return View(cartVM);
        }
        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index");
        }
        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemsCount();
        }
        public ActionResult RemoveFromCart(int PodzespolId)
        {
            ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.storeContext);

            int itemCount = shoppingCartManager.RemoveFromCart(PodzespolId);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            // Return JSON to process it in JavaScript
            var result = new CartRemoveViewModel
            {
                RemoveItemId = PodzespolId,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };

            return Json(result);
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }

        }
        public async Task<ActionResult> Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var order = new Order
                {
                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    CodeAndCity = user.UserData.CodeAndCity,
                    PhoneNumber = user.UserData.PhoneNumber,
                    Email = user.UserData.Email
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout") });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Checkout(Order orderdetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = shoppingCartManager.CreateOrder(orderdetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);
                shoppingCartManager.EmptyCart();

                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                return View(orderdetails);
            }
        }
        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}