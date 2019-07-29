using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaRepositorio repositorio;

        public TarefaController()
        {
            repositorio = new TarefaRepositorio();
        }
        // GET: Tarefa

        public ActionResult Index()
        {
            List<Tarefa> tarefas = repositorio.ObterTodos();
            ViewBag.Tarefas = tarefas;
            return View();
        }
        public ActionResult Cadastro()
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            List<Usuario> usuarios = usuarioRepositorio.ObterTodos();
            ViewBag.Usuario = usuarios;
            ProjetoRepositorio projetoRepositorio = new ProjetoRepositorio();
            List<Projeto> projetos = projetoRepositorio.ObterTodos();
            ViewBag.Projeto = projetos;
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio();
            List<Categoria> categorias = categoriaRepositorio.ObterTodos();
            ViewBag.Categoria = categorias;
            return View();
        }

        public ActionResult Store(string titulo, string descricao, DateTime duracao, int usuario, int projeto, int categoria)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            tarefa.IdUsuarioResponsavel = usuario;
            tarefa.IdProjeto = projeto;
            tarefa.IdCategoria = categoria;
            repositorio.Inserir(tarefa);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Tarefa tarefa = repositorio.ObterPeloId(id);
            ViewBag.Tarefa = tarefa;

            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            List<Usuario> usuarios = usuarioRepositorio.ObterTodos();
            ViewBag.Usuario = usuarios;

            ProjetoRepositorio projetoRepositorio = new ProjetoRepositorio();
            List<Projeto> projetos = projetoRepositorio.ObterTodos();
            ViewBag.Projeto = projetos;

            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio();
            List<Categoria> categorias = categoriaRepositorio.ObterTodos();
            ViewBag.Categoria = categorias;

            return View();
        }

        public ActionResult Update(int id, string titulo, string descricao, DateTime duracao, int usuario, int projeto, int categoria)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            tarefa.IdUsuarioResponsavel = usuario;
            tarefa.IdProjeto = projeto;
            tarefa.IdCategoria = categoria;

            repositorio.Alterar(tarefa);
            return RedirectToAction("Index");
        }
    }
}
    
