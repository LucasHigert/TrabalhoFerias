using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio repositorio;

        public CategoriaController()
        {
            repositorio = new CategoriaRepositorio();
        }

        // GET: Categoria

        public ActionResult Index()
        {
            List<Categoria> categorias = repositorio.ObterTodos();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            repositorio.Inserir(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Categoria categoria = repositorio.ObterPeloId(id);
            ViewBag.Categoria = categoria;
            return View();
        }

        public ActionResult Update(int id, string nome, string login, string senha)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            categoria.Nome = nome;

            repositorio.Alterar(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}