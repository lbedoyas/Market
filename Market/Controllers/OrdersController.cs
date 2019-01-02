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
            Session["orderView"] = orderView;

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

        public ActionResult AddProduct()
        {

            var lista = db.Products.ToList();
            lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...] " });
            lista = lista.OrderBy(p => p.Description).ToList();
            ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;

            var productID = int.Parse(Request["ProductID"]);
            if(productID == 0)
            {
                var lista = db.Products.ToList();
                lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...] " });
                lista = lista.OrderBy(p => p.Description).ToList();
                ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }

            //Este campo es para validar si el producto si existe 
            var product = db.Products.Find(productID);
            if (product == null)
            {
                var lista = db.Products.ToList();
                lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...] " });
                lista = lista.OrderBy(p => p.Description).ToList();
                ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");
                ViewBag.Error = "Producto No existe";
                return View(productOrder);
            }


            productOrder = orderView.Products.Find(p => p.ProductID == productID);
            if(productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(Request["Quantity"]),

                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }

            

            


            var listaC = db.Customers.ToList();
            listaC = listaC.OrderBy(c => c.FullName).ToList();
            listaC.Add(new Customer { CustomerId = 0, FirstName = "[Seleccion un cliente ... ]" });
            ViewBag.CustomerId = new SelectList(listaC, "CustomerId", "FullName");


            return View("NewOrder", orderView);
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