using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Entidad;
using Web.Entidad.Models;

namespace Web.Controllers
{
    [AuthLog(Roles = "Admin")]
    public class ProductosController : CommonController
    {
        //private WebContext db = new WebContext();

        IUnitOfWork unitOfWork;

        public ProductosController() : this(new UnitOfWork()) { }

        public ProductosController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        // GET: Productos
        public ActionResult Index()
        {
            var productos = unitOfWork.ProductosRepository.All();
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = unitOfWork.ProductosRepository.Find(x => x.productosId == id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(unitOfWork.CategoriasRepository.All(), "categoriaId", "detalle");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productosId,detalle,precio,categoriaId,hay")] Productos productos)
        {
            try{
                if (ModelState.IsValid)
                {
                    
                    unitOfWork.ProductosRepository.Create(productos);
                    unitOfWork.ProductosRepository.Save();
                    
                    MessageSuccess("Productos guardado con exito!");
                    return RedirectToAction("Index");
                }
            }catch(Exception e){
            ViewBag.categoriaId = new SelectList(unitOfWork.CategoriasRepository.All(), "categoriaId", "detalle", productos.categoriaId);
            MessageError("Ha ocurrido un error", e);  
                          
            }
            return View(productos); 
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = unitOfWork.ProductosRepository.Find(x => x.productosId == id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(unitOfWork.CategoriasRepository.All(), "categoriaId", "detalle", productos.categoriaId);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productosId,detalle,precio,categoriaId,hay")] Productos productos)
        {
            
                if (ModelState.IsValid)
                {
                    try{
                        unitOfWork.ProductosRepository.Update(productos);
                        unitOfWork.ProductosRepository.Save();
             
                        MessageSuccess("Productos guardado con exito!");
                        return RedirectToAction("Index");
                    }catch(Exception e){
                        MessageError("Ha ocurrido un error", e);  
                    }
                }
            
                ViewBag.categoriaId = new SelectList(unitOfWork.CategoriasRepository.All(), "categoriaId", "detalle", productos.categoriaId);
         return View(productos);
            
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {          
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Productos productos = unitOfWork.ProductosRepository.Find(x => x.productosId == id);
                unitOfWork.ProductosRepository.Delete(productos);
                unitOfWork.ProductosRepository.Save();
                
                if (productos == null)
                {
                    return HttpNotFound();
                }
                MessageSuccess("Productos eliminado con exito!");
            }catch(Exception e){
                 MessageError("Ha ocurrido un error", e);               
            }
            return RedirectToAction("Index");
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
