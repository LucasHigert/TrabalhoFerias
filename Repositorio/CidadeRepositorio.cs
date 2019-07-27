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
    public class CidadeRepositorio
    {
        public List<Cidade> ObterTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT*FORM cidades";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            List<Cidade> cidades = new List<Cidade>();

            foreach (DataRow linha in tabela.Rows)
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt32(linha["id"]);
                cidade.Nome = linha["nome"].ToString();
                cidade.Cpf = linha["cpf"].ToString();
                cidade.IdEstado = Convert.ToInt32(linha["idEstado"]);               
            }
            comando.Connection.Close();
            return cidades;
        }

        public int Inserir(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO cidades (nome, cpf, idEstado, estado) OUTPUT INSERTED.ID VALUES (@NOME, @CPF, @IDESTADO, @ESTADO)";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@CPF", cidade.Cpf);
            comando.Parameters.AddWithValue("@IDESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@ESTADO", cidade.Estado);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public Cidade ObterPeloId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM cidades WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];
            Cidade cidade = new Cidade();
            cidade.Id = Convert.ToInt32(linha["id"]);
            cidade.Nome = linha["nome"].ToString();
            cidade.Cpf = linha["cpf"].ToString();
            cidade.IdEstado = Convert.ToInt32(linha["idEstado"]);
            return cidade;
        }

        public bool Alterar(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "UPDATE cidades SET nome = @NOME, cpf = @CPF, idEstado = @IDESTADO, estado = @ESTADO WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@CPF", cidade.Cpf);
            comando.Parameters.AddWithValue("@IDESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@ESTADO", cidade.Estado);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM ciades WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
