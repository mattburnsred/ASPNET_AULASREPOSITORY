using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula_13._06_MVC.Models;

namespace Aula_13._06_MVC.Controllers
{
    public class CategoriasController : Controller
    {
        public ActionResult Index()
        {
            #region [Old]
            //List<string> categorias = new List<string>();
            //categorias.Add("Carros");
            //categorias.Add("Barcos");
            //categorias.Add("Aviões");
            //categorias.Add("Espaçunavis");

            //ViewBag.Categorias = categorias; 
            #endregion

            List<Categoria> categorias = new List<Categoria>();
            categorias.Add((new Categoria() { Id = 1, Nome = "Carros" }));
            categorias.Add((new Categoria() { Id = 2, Nome = "Motos" }));
            categorias.Add((new Categoria() { Id = 3, Nome = "Barcos" }));
            categorias.Add((new Categoria() { Id = 4, Nome = "Aviões" }));

            return View("Index", categorias);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria model)
        {
            try
            {
                // Setar Id
            }
            catch (Exception e)
            {
                throw;
            }

            return View("Index");
        }
    }
}