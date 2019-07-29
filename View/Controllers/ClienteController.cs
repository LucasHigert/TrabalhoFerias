using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteRepositorio repositorio;

        public ClienteController()
        {
            repositorio = new ClienteRepositorio();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastro()
        {
            CidadeRepositorio cidadeRepositorio = new CidadeRepositorio();
            List<Cidade> cidades = cidadeRepositorio.ObterTodos();
            ViewBag.Cidade = cidades;
            return View();
        }

        public ActionResult Store(string nome, int cidade, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.IdCidade = cidade;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;
            repositorio.Inserir(cliente);
            return RedirectToAction("Index");
        }
        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cliente cliente = repositorio.ObterPeloId(id);
            ViewBag.Cliente = cliente;

            CidadeRepositorio cidadeRepositorio = new CidadeRepositorio();
            List<Cidade> cidades = cidadeRepositorio.ObterTodos();

            ViewBag.Cidade = cidades;

            return View();
        }
        public ActionResult Update(int id, string nome, int cidade, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.IdCidade = cidade;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;

            repositorio.Alterar(cliente);
            return RedirectToAction("Index");
        }
    }
}
