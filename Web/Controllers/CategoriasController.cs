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
    public class CategoriasController : CommonController
    {
        //private WebContext db = new WebContext();

        IUnitOfWork unitOfWork;

        public CategoriasController() : this(new UnitOfWork()) { }

        public CategoriasController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(unitOfWork.CategoriasRepository.All().ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = unitOfWork.CategoriasRepository.Find(x => x.categoriaId == id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // GET: Categorias/Create
        public ActionResult Create(int? partial = 0)
        {
            if (partial == 0)
                return View();
            else
            {
                ViewBag.Partial = true;
                return PartialView();
            }
                
        }

        // POST: Categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoriaId,detalle")] Categorias categorias)
        {
            try{
                if (ModelState.IsValid)
                {
                    
                    unitOfWork.CategoriasRepository.Create(categorias);
                    unitOfWork.CategoriasRepository.Save();
                    
                    MessageSuccess("Categorias guardado con exito!");
                    return RedirectToAction("Index");
                }
            }catch(Exception e){
            MessageError("Ha ocurrido un error", e);  
                          
            }
            return View(categorias); 
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = unitOfWork.CategoriasRepository.Find(x => x.categoriaId == id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoriaId,detalle")] Categorias categorias)
        {
            
                if (ModelState.IsValid)
                {
                    try{
                        unitOfWork.CategoriasRepository.Update(categorias);
                        unitOfWork.CategoriasRepository.Save();
             
                        MessageSuccess("Categorias guardado con exito!");
                        return RedirectToAction("Index");
                    }catch(Exception e){
                        MessageError("Ha ocurrido un error", e);  
                    }
                }
            
         return View(categorias);
            
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {          
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Categorias categorias = unitOfWork.CategoriasRepository.Find(x => x.categoriaId == id);
                unitOfWork.CategoriasRepository.Delete(categorias);
                unitOfWork.CategoriasRepository.Save();
                
                if (categorias == null)
                {
                    return HttpNotFound();
                }
                MessageSuccess("Categorias eliminado con exito!");
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
