using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoRepositorio repositorio;

        public ProjetoController()
        {
            repositorio = new ProjetoRepositorio();
        }
        // GET: Projeto

        public ActionResult Index()
        {
            List<Projeto> projetos = repositorio.ObterTodos();
            ViewBag.Projetos = projetos;
            return View();
        }
        public ActionResult Editar(int id)
        {
            Projeto projeto = repositorio.ObterPeloId(id);
            ViewBag.Projeto = projeto;

            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            List<Cliente> clientes = clienteRepositorio.ObterTodos();
            ViewBag.Clientes = clientes;

            return View();
        }

        public ActionResult Atualizar(int id, int clienteNome, string nomeProjeto, DateTime dataCriacao, DateTime dataConclusao)
        {
            Projeto projeto = new Projeto();
            projeto.Id = id;
            projeto.Nome = nomeProjeto;
            projeto.DataCriacao = dataCriacao;
            projeto.DataConclusao = dataConclusao;
            projeto.IdCliente = clienteNome;

            repositorio.Alterar(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastro()
        {
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            List<Cliente> clientes = clienteRepositorio.ObterTodos();
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Store(int cliente, string projetoNome, DateTime dataConclusao, DateTime dataCriacao)
        {
            Projeto projeto = new Projeto();
            projeto.Nome = projetoNome;
            projeto.IdCliente = cliente;
            projeto.DataConclusao = dataConclusao;
            projeto.DataCriacao = dataCriacao;
            repositorio.Inserir(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

    }
}
