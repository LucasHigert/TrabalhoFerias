using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CidadeController : Controller
    {
        private CidadeRepositorio repositorio;

        public CidadeController()
        {
            repositorio = new CidadeRepositorio();
        }

        // GET: Cidade

        public ActionResult Index()
        {
            List<Cidade> cidades = repositorio.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Cadastro()
        {
            EstadoRepositorio estadoRepositorio = new EstadoRepositorio();
            List<Estado> estados = estadoRepositorio.ObterTodos();
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Store(string nome, int estado,int numeroHabitantes)
        {
            Cidade cidade = new Cidade();
            cidade.Nome = nome;
            cidade.IdEstado = estado;
            cidade.NumeroHabitantes = numeroHabitantes;
            repositorio.Inserir(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade cidade = repositorio.ObterPeloId(id);
            ViewBag.Cidade = cidade;

            EstadoRepositorio estadoRepositorio = new EstadoRepositorio();
            List<Estado> estados= estadoRepositorio.ObterTodos();
            ViewBag.Estados = estados;

            return View();
        }

        public ActionResult Update(int id, string nome, int estado,int numeroHabitantes)
        {
            Cidade cidade = new Cidade();
            cidade.Nome = nome;
            cidade.Id = id;
            cidade.IdEstado = estado;
            cidade.NumeroHabitantes = numeroHabitantes;
            
            repositorio.Alterar(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}