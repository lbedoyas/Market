using Market.Models;
using Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class OrdersController : Controller
    {
        // Instanciamos la BD
        private MarketContext db = new MarketContext();
        // GET: Orders
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();

            var lista = db.Customers.ToList();
            lista.Add(new Customer { CustomerId = 0, FirstName = "[Seleccion un cliente ... ]"} );
            lista = lista.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerId = new SelectList(lista, "CustomerId", "FullName");            
            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            var lista = db.Customers.ToList();
            lista = lista.OrderBy(c => c.FullName).ToList();
            lista.Add(new Customer { CustomerId = 0, FirstName = "[Seleccion un cliente ... ]" });
            ViewBag.CustomerId = new SelectList(lista, "CustomerId", "FullName");
            return View(orderView);
        }

        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var lista = db.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...] " });
            lista = lista.OrderBy(p => p.Description).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");

            return View(productOrder);
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection form)
        {
            var lista = db.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...] " });
            lista = lista.OrderBy(p => p.Description).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");

            return View();
        }


        //Hacemos la liberacion del recurso para cerrar la BD y no tener conexiones abiertas
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}