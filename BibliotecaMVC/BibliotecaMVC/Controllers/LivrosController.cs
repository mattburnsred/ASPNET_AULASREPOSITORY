using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro model)
        {
            if (ModelState.IsValid)
            {
                _context.Livros.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome", model.IdCategoria);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome", model.IdCategoria);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome", model.IdCategoria);

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Livro model = _context.Livros.Find(Id);
            _context.Livros.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }



        // Exemplo Dropdownlists em sequencia

        //public JsonResult GetProdutosByCategoria(int idCategoria)
        //{
        //    var produtos = db.Produtos.Where(p => p.CategoriaID == idCategoria).ToList();

        //    return Json(produtos, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult ExibirPorCategoria()
        //{
        //    ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
        //    ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ExibirPorCategoria(FormCollection campos)
        //{
        //    string categoriaID = campos["CategoriaID"];
        //    string produtoID = campos["ProdutoID"];

        //    ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
        //    ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
        //    return View();
        //}
    }
}
