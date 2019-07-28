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
            SqlCommand comando = Conexao.Conectar();        
            comando.CommandText = "SELECT*FROM cidades";
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
                cidade.DataNascimento = Convert.ToDateTime(linha["dataNascimento"]);
                cidade.Numero = Convert.ToInt32(linha["numero"]);
                cidade.Complemento = linha["complemento"].ToString();
                cidade.Logradouro = linha["logradouro"].ToString();
                cidade.Cep = linha["cep"].ToString();
            }
            comando.Connection.Close();
            return cidades;
        }

        public int Inserir(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO cidades (nome, cpf, id_estado, estado, data_nascimento, numero, complemeto, logradouro, cep) OUTPUT INSERTED.ID VALUES (@NOME, @CPF, @ID_ESTADO, @ESTADO, @DATA_NASCIMENTO, @NUMERO, @COMPLEMENTO, @LOGRADOURO, @CEP)";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@CPF", cidade.Cpf);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@ESTADO", cidade.Estado);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cidade.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cidade.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cidade.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cidade.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cidade.Cep);
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
            cidade.DataNascimento = Convert.ToDateTime(linha["dataNascimento"]);
            cidade.Numero = Convert.ToInt32(linha["numero"]);
            cidade.Complemento = linha["complemento"].ToString();
            cidade.Logradouro = linha["logradouro"].ToString();
            cidade.Cep = linha["cep"].ToString();
            return cidade;
        }

        public bool Alterar(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "UPDATE cidades SET nome = @NOME, cpf = @CPF, idEstado = @ID_ESTADO, estado = @ESTADO WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@CPF", cidade.Cpf);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@ESTADO", cidade.Estado);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cidade.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cidade.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cidade.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cidade.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cidade.Cep);
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
