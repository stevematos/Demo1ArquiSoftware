using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        BodegaEntities bd = new BodegaEntities();
        public ActionResult Administrador()
        {
            ViewBag.listaoferta = bd.OFFER.ToList();
            decimal total = 0;
            foreach (var item in bd.DETAIL.ToList())
            {
                total += item.QUANTITY * item.PRODUCT.UNIT_COST;
            }
            ViewBag.total = total;
            return View();
        }
        [HttpGet]
        public ActionResult Empleado()
        {
            ViewBag.Message = "Lista de productos";
            ViewBag.Message2 = "Lista de ofertas";
            ViewBag.listaoferta = bd.OFFER.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Empleado(String idProducto, int Cantidad)
        {
            ViewBag.Message = "Lista de productos";
            ViewBag.Message2 = "Lista de ofertas";
            ViewBag.listaoferta = bd.OFFER.ToList();
            String id = (String.Format("{0,-"+bd.PRODUCT.ToList().First().ID_PRODUCT.Length+"}", idProducto));
            var producto = bd.PRODUCT.Find(id);
            ((List<PRODUCT>)Session["Productos"]).Add(producto);
            Session["Monto Total"] = (decimal)Session["Monto Total"] + producto.UNIT_PRICE * Cantidad;
            ((List<ProductosCantidad>)Session["Productos_cantidad"]).Add(new ProductosCantidad(idProducto, Cantidad));
            return View();
        }
        [HttpPost]
        public ActionResult Empleado2(String idBorrar)
        {
            ViewBag.Message = "Lista de productos";
            ViewBag.Message2 = "Lista de ofertas";
            ViewBag.listaoferta = bd.OFFER.ToList();
            String id = (String.Format("{0,-" + bd.PRODUCT.ToList().First().ID_PRODUCT.Length + "}", idBorrar));
            PRODUCT producto = bd.PRODUCT.Find(id);
            int cantidad = 0;
            for (int i = 0; i < ((List<PRODUCT>)Session["Productos"]).Count; i++)
            {
                if(id==((List<PRODUCT>)Session["Productos"])[i].ID_PRODUCT)
                    ((List<PRODUCT>)Session["Productos"]).Remove(((List<PRODUCT>)Session["Productos"])[i]);
            }
            foreach (var item in (List<ProductosCantidad>)Session["Productos_cantidad"])
            {
                if (item.idproducto == idBorrar)
                    cantidad = item.cantidad;
            }
            Session["Monto Total"] = (decimal)Session["Monto Total"] - producto.UNIT_PRICE * cantidad ;
            return View("Empleado");
        }
        [HttpPost]
        public ActionResult Empleado3()
        {
            ViewBag.Message = "Lista de productos";
            ViewBag.Message2 = "Lista de ofertas";
            ViewBag.listaoferta = bd.OFFER.ToList();
            foreach (var item in (List<ProductosCantidad>)Session["Productos_cantidad"])
            {
                PRODUCT producto = new PRODUCT();
                for (int i = 0; i < ((List<PRODUCT>)Session["Productos"]).Count; i++)
                {
                    String id = (String.Format("{0,-" + bd.PRODUCT.ToList().First().ID_PRODUCT.Length + "}", item.idproducto));
                    if (id == ((List<PRODUCT>)Session["Productos"])[i].ID_PRODUCT)
                        producto = ((List<PRODUCT>)Session["Productos"])[i];
                }
                bd.DETAIL.Add(new DETAIL{
                            ID_PRODUCT = item.idproducto,
                            ID_SALE="001",
                            QUANTITY=item.cantidad,
                            SALE_PRICE=producto.UNIT_COST*item.cantidad,
                            DISCOUNT=0
                    });
            }

            return View("Empleado");
        }
        [HttpGet]
        public ActionResult Buscar()
        {
            ViewBag.Message = "Busqueda por cliente";
            ViewBag.Message2 = "Busqueda por fecha";
            ViewBag.Message3 = "Busqueda por empleado";
            ViewBag.listadocliente = new List<SALE>();
            ViewBag.listadoempleado = new List<SALE>();
            ViewBag.listadofecha = new List<SALE>();
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(String nombreCliente )
        {
            ViewBag.listadoempleado = new List<SALE>();
            ViewBag.listadofecha = new List<SALE>();
            List<SALE> lista = new List<SALE>();
            foreach (var cliente in bd.SALE.ToList())
            {
                if (nombreCliente == cliente.EMPLOYEE.FATHER_LASTNAME)
                {
                    lista.Add(cliente);
                }
            }
            ViewBag.listadocliente = lista;
            return View();
        }
        [HttpPost]
        public ActionResult Buscar2(String fecha)
        {
            ViewBag.listadoempleado = new List<SALE>();
            ViewBag.listadocliente = new List<SALE>();
            List<SALE> lista = new List<SALE>();
            foreach (var venta in bd.SALE.ToList())
            {
                if (fecha == venta.SALE_DATE.ToString())
                {
                    lista.Add(venta);
                }
            }
            ViewBag.listadofecha = lista;
            return View("Buscar");
        }
        [HttpPost]
        public ActionResult Buscar3(String idempleado)
        {
            ViewBag.listadocliente = new List<SALE>();
            ViewBag.listadofecha = new List<SALE>();
            List<SALE> lista = new List<SALE>();
            foreach (var venta in bd.SALE.ToList())
            {
                if (idempleado == venta.ID_EMPLOYEE)
                {
                    lista.Add(venta);
                }
            }
            ViewBag.listadoempleado = lista;
            return View("Buscar");
        }
    }
}