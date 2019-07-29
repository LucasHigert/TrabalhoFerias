using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EstadoController : Controller
    {
        private EstadoRepositorio repositorio;

        public EstadoController()
        {
            repositorio = new EstadoRepositorio();
        }

        // GET: Usuario

        public ActionResult Index()
        {
            List<Estado> estados = repositorio.ObterTodos();
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, string sigla)
        {
            Estado estado = new Estado();
            estado.Nome = nome;
            estado.Sigla = sigla;
            repositorio.Inserir(estado);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Estado estado = repositorio.ObterPeloId(id);
            ViewBag.Estado = estado;
            return View();
        }

        public ActionResult Update(int id, string nome, string sigla)
        {
            Estado estado = new Estado();
            estado.Id = id;
            estado.Nome = nome;
            estado.Sigla = sigla;

            repositorio.Alterar(estado);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}