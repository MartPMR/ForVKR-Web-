using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using Library.Domain.Entities;
using Library.Web.Models;
using Library.Web.Infrastructure.Binders;
using Library.Services;

namespace Library.Web.Controllers
{
    public class CartController : Controller
    {
        private IOrderProcessor orderProcessor;
        private CatalogService srvCatalog;

        public CartController(IOrderProcessor processor, CatalogService srvCatalog)
        {
            orderProcessor = processor;
            this.srvCatalog = srvCatalog;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        [Authorize]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                srvCatalog.CreateOrderBooks(User.Identity.GetUserName(), cart);
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        [Authorize]
        public RedirectToRouteResult AddToCart(Cart cart, int id_book, string returnUrl)
        {
            Book book = srvCatalog.SelectBook(id_book);
            if (book != null) cart.AddItem(book, 1);
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id_book, string returnUrl)
        {
            Book book = srvCatalog.SelectBook(id_book);
            if (book != null) cart.RemoveLine(book);
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}