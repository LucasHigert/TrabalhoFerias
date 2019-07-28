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
            return View();
        }

        public ActionResult Store(string nome, string cpf, int idEstado, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cidade cidade = new Cidade();
            cidade.Nome = nome;
            cidade.Cpf = cpf;
            cidade.IdEstado = idEstado;
            cidade.DataNascimento = dataNascimento;
            cidade.Numero = numero;
            cidade.Complemento = complemento; 
            cidade.Logradouro = logradouro;
            cidade.Cep = cep;
            repositorio.Inserir(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade cidade = repositorio.ObterPeloId(id);
            ViewBag.Cidade = cidade;
            return View();
        }

        public ActionResult Update(int id, string nome, string cpf, int idEstado, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cidade cidade = new Cidade();
            cidade.Nome = nome;
            cidade.Cpf = cpf;
            cidade.IdEstado = idEstado;
            cidade.DataNascimento = dataNascimento;
            cidade.Numero = numero;
            cidade.Complemento = complemento;
            cidade.Logradouro = logradouro;
            cidade.Cep = cep;

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