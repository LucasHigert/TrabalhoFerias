using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepositorio repositorio;

        public UsuarioController()
        {
            repositorio = new UsuarioRepositorio();
        }

        // GET: Usuario

        public ActionResult Index()
        {
            List<Usuario> usuarios = repositorio.ObterTodos();
            ViewBag.Usuarios = usuarios;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;
            repositorio.Inserir(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Usuario usuario = repositorio.ObterPeloId(id);
            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult Update(int id, string nome, string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Nome = nome;
            usuario.Login = login;
            usuario.Senha = senha;

            repositorio.Alterar(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}