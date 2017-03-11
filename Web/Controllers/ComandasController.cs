using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Models;
using Web.Entidad;
using Web.Entidad.Models;

namespace Web.Controllers
{
    public class ComandasController : CommonController
    {
        //private CSPOSContext db = new CSPOSContext();

        IUnitOfWork unitOfWork;

        public ComandasController() : this(new UnitOfWork()) { }

        public ComandasController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public IEnumerable<SelectListItem> listaCategorias(int? selected = 0)
        {
            var lista = unitOfWork.CategoriasRepository.All().Select(x => new SelectListItem
            {
                Selected = (x.categoriaId == selected.Value),
                Text = x.detalle,
                Value = x.categoriaId.ToString()
            });

            return lista;

        }
        public ActionResult Index()
        {
            UnitOfWork uow = new UnitOfWork();
            var asd = uow.ComandasRepository.All().ToList();
            return View(asd);
        }
        [HttpPost]
        public ActionResult agregarComanda(ComandaModel model)
        {
            UnitOfWork uow = new UnitOfWork();

            Comandas comanda = new Comandas
            {
                nombreUsuario = User.Identity.Name,
                precioTotal = model.listaPedido.Sum(a => a.precio),
                fecha = DateTime.Now
            };
            var com = uow.ComandasRepository.Create(comanda);
            uow.ComandasRepository.Save();

            foreach (var comida in model.listaPedido)
            {
                DetalleComandas detalleComida = new DetalleComandas();
                detalleComida.cantidad = comida.cantidad;
                detalleComida.comandasId = com.comandasId;
                detalleComida.nombreComida = comida.nombre;
                detalleComida.precio = comida.precio;
                var comida2 = uow.DetalleComandasRepository.Create(detalleComida);
                uow.DetalleComandasRepository.Save();

            }
            SetTempData("Pedido cargado con exito");
            return RedirectToAction("/listapedido");
        }
        // GET: Comandas
        public ActionResult NuevaComanda()
        {

            ViewData["categoriaId"] = listaCategorias();
            var listaSPedidos = (List<ProductosPedidos>)Session["listaPedidos"];
            ViewBag.contador = 0;
            return View();
        }
        public ActionResult DetalledeComanda(int? comandasId)
        {
            if (comandasId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comandas comandas = unitOfWork.ComandasRepository.Find(x => x.comandasId == comandasId);
            if (comandas == null)
            {
                return HttpNotFound();
            }
            return View(comandas);
        }
        public ActionResult ListaPedidos(int productoId)
        {
            if (Session["listaPedidos"] == null)
            {
                Session["listaPedidos"] = new List<ProductosPedidos>();
            }
            var lista = (List<ProductosPedidos>)Session["listaPedidos"];
            var producto = unitOfWork.ProductosRepository.Find(a => a.productosId == productoId);
            var cantidad = lista.Count(a => a.productoPedidoId == producto.productosId) == 0 ? 1 : lista.Count(a => a.productoPedidoId == producto.productosId);

            lista.Add(new ProductosPedidos()
            {
                productoPedidoId = producto.productosId,
                nombre = producto.detalle,
                cantidad = lista != null ? lista.Any(a => a.productoPedidoId == producto.productosId) ? cantidad++ : cantidad : cantidad,
                precio = producto.precio * (lista != null ? lista.Any(a => a.productoPedidoId == producto.productosId) ? cantidad++ : cantidad : cantidad)
            });

            Session["listaPedidos"] = lista;
            return PartialView("_partialListaPedidos", lista);
        }
        public ActionResult listaProductos(int? categoriaId)
        {
            var lista = unitOfWork.ProductosRepository.Filter(x => x.categoriaId == categoriaId);
            return PartialView("_partialProductos", lista.ToList());
        }
        // GET: Comandas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comandas comandas = unitOfWork.ComandasRepository.Find(x => x.comandasId == id);
            if (comandas == null)
            {
                return HttpNotFound();
            }
            return View(comandas);
        }

        // GET: Comandas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comandas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "comandaId,userId,fecha,user")] Comandas comandas)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    unitOfWork.ComandasRepository.Create(comandas);
                    unitOfWork.ComandasRepository.Save();

                    MessageSuccess("Comandas guardado con exito!");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                MessageError("Ha ocurrido un error", e);

            }
            return View(comandas);
        }

        // GET: Comandas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comandas comandas = unitOfWork.ComandasRepository.Find(x => x.comandasId == id);
            if (comandas == null)
            {
                return HttpNotFound();
            }
            return View(comandas);
        }

        // POST: Comandas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "comandaId,userId,fecha,user")] Comandas comandas)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.ComandasRepository.Update(comandas);
                    unitOfWork.ComandasRepository.Save();

                    MessageSuccess("Comandas guardado con exito!");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageError("Ha ocurrido un error", e);
                }
            }

            return View(comandas);

        }

        // GET: Comandas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Comandas comandas = unitOfWork.ComandasRepository.Find(x => x.comandasId == id);
                unitOfWork.ComandasRepository.Delete(comandas);
                unitOfWork.ComandasRepository.Save();

                if (comandas == null)
                {
                    return HttpNotFound();
                }
                MessageSuccess("Comandas eliminado con exito!");
            }
            catch (Exception e)
            {
                MessageError("Ha ocurrido un error", e);
            }
            return RedirectToAction("listaPedido");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
