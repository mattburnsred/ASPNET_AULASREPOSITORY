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
            List<Livro> livros = _context.Livros.ToList();
            if (livros.Count > 0)
            {
                return View(livros);
            }

            return View("Index");
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

        //public JsonResult GetProdutosByCategoria(int idCategoria)
        //{
        //    var produtos = _context.Livros.Where(m => m.IdCategoria == idCategoria).ToList();

        //    return Json(produtos, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult ExibirPorCategoria()
        //{
        //    ViewBag.IdCategoria = new SelectList(_context.Categorias, "Id", "Nome");
        //    ViewBag.IdProduto = new SelectList(_context.Livros, "Id", "Nome");

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ExibirPorCategoria(FormCollection campos)
        //{
        //    string categoriaID = campos["IdCategoria"];
        //    string produtoID = campos["IdProduto"];

        //    ViewBag.CategoriaID = new SelectList(_context.Categorias, "CategoriaID", "Nome");
        //    ViewBag.ProdutoID = new SelectList(_context.Livros, "ProdutoID", "Nome");

        //    return View();
        //}
    }
}
