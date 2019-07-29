﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class TarefaRepositorio
    {
        public int Inserir(Tarefa tarefa)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO tarefas(titulo, descricao, duracao, id_usuario_responsavel, id_projeto, id_categoria)
            OUTPUT INSERTED.ID VALUES (@TITULO, @DESCRICAO, @DURACAO, @ID_USUARIO_RESPONSAVEL, @ID_PROJETO, @ID_CATEGORIA)";
            comando.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            comando.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            comando.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            comando.Parameters.AddWithValue("@ID_USUARIO_RESPONSAVEL", tarefa.IdUsuarioResponsavel);
            comando.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            comando.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Tarefa> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT tarefas.id AS 'TarefaId',
            tarefas.titulo AS 'TarefaTitulo',
            tarefas.descricao AS 'TarefaDescricao',
            FORMAT(tarefas.duracao, 'hh:mm:ss') AS 'TarefaDuracao',
            usuarios.nome AS 'UsuarioNome',
            projetos.nome AS 'ProjetoNome',
            categorias.nome AS 'CategoriaNome' FROM tarefas INNER JOIN usuarios ON (tarefas.id_usuario_responsavel = usuarios.id) 
            INNER JOIN projetos ON (tarefas.id_projeto = projetos.id) INNER JOIN categorias ON (tarefas.id_categoria = categorias.id)";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (DataRow linha in tabela.Rows)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Id = Convert.ToInt32(linha["TarefaId"]);
                tarefa.Titulo = linha["TarefaTitulo"].ToString();
                tarefa.Descricao = linha["TarefaDescricao"].ToString();
                tarefa.Duracao = Convert.ToDateTime(linha["TarefaDuracao"]);

                tarefa.Usuario = new Usuario();
                tarefa.Usuario.Nome = linha["UsuarioNome"].ToString();

                
                tarefa.Projeto = new Projeto();
                tarefa.Projeto.Nome = linha["ProjetoNome"].ToString();

                tarefa.Categoria = new Categoria();
                tarefa.Categoria.Nome = linha["CategoriaNome"].ToString();

                tarefas.Add(tarefa);
            }
            return tarefas;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "DELETE FROM tarefas WHERE @ID = id";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public Tarefa ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT tarefas.id AS 'TarefaId',
            tarefas.titulo AS 'TarefaTitulo',
            tarefas.descricao AS 'TarefaDescricao',
            FORMAT(tarefas.duracao, 'hh:mm:ss') AS 'TarefaDuracao',
            usuarios.nome AS 'UsuarioNome',
            projetos.nome AS 'ProjetoNome',
            categorias.nome AS 'CategoriaNome' FROM tarefas INNER JOIN usuarios ON (tarefas.id_usuario_responsavel = usuarios.id) 
            INNER JOIN projetos ON (tarefas.id_projeto = projetos.id) INNER JOIN categorias ON (tarefas.id_categoria = categorias.id)";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];

            Tarefa tarefa = new Tarefa();
            tarefa.Id = Convert.ToInt32(linha["TarefaId"]);
            tarefa.Titulo = linha["TarefaTitulo"].ToString();
            tarefa.Descricao = linha["TarefaDescricao"].ToString();
            tarefa.Duracao = Convert.ToDateTime(linha["TarefaDuracao"]);

            tarefa.Usuario = new Usuario();
            tarefa.Usuario.Nome = linha["UsuarioNome"].ToString();

            tarefa.Projeto = new Projeto();
            tarefa.Projeto.Nome = linha["ProjetoNome"].ToString();

            tarefa.Categoria = new Categoria();
            tarefa.Categoria.Nome = linha["CategoriaNome"].ToString();

            return tarefa;
        }

        public bool Alterar(Tarefa tarefa)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"UPDATE tarefas SET
                                        titulo = @TITULO,
                                        descricao = @DESCRICAO,
                                        duracao = @DURACAO,
                                        id_usuario_responsavel = @ID_USUARIO_RESPONSAVEL,
                                        id_projeto = @ID_PROJETO,
                                        id_categoria = @ID_CATEGORIA
                                     WHERE id = @ID";
            comando.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            comando.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            comando.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            comando.Parameters.AddWithValue("@ID_USUARIO_RESPONSAVEL", tarefa.IdUsuarioResponsavel);
            comando.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            comando.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            comando.Parameters.AddWithValue("@ID", tarefa.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
    
