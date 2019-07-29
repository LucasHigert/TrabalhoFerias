using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ProjetoRepositorio
    {
        public List<Projeto> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT 
            projetos.id AS 'ProjetoId', 
            projetos.nome AS 'ProjetoNome', 
            projetos.data_criacao AS 'DataCriacao',
            projetos.data_finalizacao AS 'DataFinalizacao',
            clientes.nome AS 'ClienteNome'
            FROM projetos INNER JOIN clientes ON (projetos.id_cliente = clientes.id)";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Projeto> projetos = new List<Projeto>();
            foreach (DataRow linha in tabela.Rows)
            {
                Projeto projeto = new Projeto();
                projeto.Id = Convert.ToInt32(linha["projetoId"]);
                projeto.Nome = linha["ProjetoNome"].ToString();
                projeto.DataCriacao = Convert.ToDateTime(linha["DataCriacao"]);
                projeto.DataConclusao = Convert.ToDateTime(linha["DataFinalizacao"]);
                projeto.Cliente = new Cliente();
                projeto.Cliente.Nome = linha["ClienteNome"].ToString();
                projetos.Add(projeto);
            }

            return projetos;
        }

        public Projeto ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT projetos.id AS 'ProjetoId', projetos.Nome AS 'ProjetoNome', projetos.data_criacao AS 'ProjetoDataCriacao', projetos.data_finalizacao AS 'ProjetoDataConclusao', projetos.id_cliente as 'ProjetoClienteId', clientes.Nome AS 'ProjetoClienteNome' FROM projetos INNER JOIN clientes ON (projetos.id_cliente = clientes.id) WHERE projetos.id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Projeto> projetos = new List<Projeto>();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];
            Projeto projeto = new Projeto();
            projeto.Id = Convert.ToInt32(linha["ProjetoId"]);
            projeto.Nome = linha["ProjetoNome"].ToString();
            projeto.IdCliente = Convert.ToInt32(linha["ProjetoClienteId"]);
            projeto.DataCriacao = Convert.ToDateTime(linha["ProjetoDataCriacao"]);
            projeto.DataConclusao = Convert.ToDateTime(linha["ProjetoDataConclusao"]);
            projeto.Cliente = new Cliente();
            projeto.Cliente.Nome = linha["ProjetoClienteNome"].ToString();

            return projeto;
        }

        public bool Alterar(Projeto projeto)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "UPDATE projetos SET nome = @NOME, data_criacao = @DATA_CRIACAO, data_finalizacao = @DATA_CONCLUSAO, id_cliente = @ID_CLIENTE WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", projeto.Id);
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.DataCriacao);
            comando.Parameters.AddWithValue("@DATA_CONCLUSAO", projeto.DataConclusao);
            comando.Parameters.AddWithValue("@ID_CLIENTE", projeto.IdCliente);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Projeto projeto)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "INSERT INTO projetos (nome, id_cliente, data_criacao, data_finalizacao) OUTPUT INSERTED.ID VALUES (@NOME, @ID_CLIENTE, @DATA_CRIACAO, @DATA_CONCLUSAO)";
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@ID_CLIENTE", projeto.IdCliente);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.DataCriacao);
            comando.Parameters.AddWithValue("@DATA_CONCLUSAO", projeto.DataConclusao);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "DELETE FROM projetos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }

}

