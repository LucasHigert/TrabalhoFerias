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
    public class ClienteRepositorio
    {
        public List<Cliente> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT clientes.id AS 'ClienteId', 
clientes.id_cidade AS 'IdCidades',
clientes.nome AS 'ClienteNome', 
clientes.cpf AS 'ClienteCpf', 
clientes.data_nascimento AS 'ClienteDataNascimento',
clientes.numero AS 'ClienteNumero', 
clientes.complemento AS 'ClienteComplemento', 
clientes.logradouro AS 'ClienteLogradouro',
clientes.cep AS 'ClienteCEP',
cidades.nome AS 'CidadeNome' FROM clientes INNER JOIN cidades ON (clientes.id_cidade = cidades.id) INNER JOIN estados ON (cidades.id_estado = estados.id)";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Cliente> clientes = new List<Cliente>();

            foreach (DataRow linha in tabela.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(linha["ClienteId"]);
                cliente.Nome = linha["ClienteNome"].ToString();
                cliente.Cpf = linha["ClienteCpf"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(linha["ClienteDataNascimento"]);
                cliente.Numero = Convert.ToInt32(linha["ClienteNumero"]);
                cliente.Complemento = linha["ClienteComplemento"].ToString();
                cliente.Logradouro = linha["ClienteLogradouro"].ToString();
                cliente.Cep = linha["ClienteCEP"].ToString();

                cliente.Cidade = new Cidade();
                cliente.Cidade.Nome = linha["CidadeNome"].ToString();


                clientes.Add(cliente);
            }

            return clientes;

        }
        public int Inserir(Cliente cliente)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO clientes (id_cidade, nome, cpf, data_nascimento, numero, complemento, logradouro, cep) OUTPUT INSERTED.ID VALUES (@ID_CIDADE, @NOME, @CPF, @DATA_NASCIMENTO, @NUMERO, @COMPLEMENTO, @LOGRADOURO, @CEP)";
            comando.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);

            int id = Convert.ToInt32(comando.ExecuteScalar());

            comando.Connection.Close();

            return id;
        }
        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = "DELETE FROM clientes WHERE @ID = id";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public Cliente ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT clientes.id AS 'ClienteId', 
clientes.nome AS 'ClienteNome', 
cidades.nome AS 'CidadeNome',
clientes.id_cidade AS 'ClienteIdCidade',
clientes.cpf AS 'ClienteCpf', 
FORMAT(clientes.data_nascimento, 'dd/MM/yyyy') AS 'ClienteDataNascimento',
clientes.numero AS 'ClienteNumero', 
clientes.complemento AS 'ClienteComplemento', 
clientes.logradouro AS 'ClienteLogradouro',
clientes.cep AS 'ClienteCEP' FROM clientes INNER JOIN cidades ON (clientes.id_cidade = cidades.id) INNER JOIN estados ON (cidades.id_estado = estados.id) WHERE @ID = clientes.id";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }


            DataRow linha = tabela.Rows[0];

            Cliente cliente = new Cliente();

            cliente.Id = Convert.ToInt32(linha["ClienteId"]);
            cliente.Nome = linha["CidadeNome"].ToString();
            cliente.IdCidade = Convert.ToInt32(linha["ClienteId"]);
            cliente.Cpf = linha["ClienteCpf"].ToString();
            cliente.DataNascimento = Convert.ToDateTime(linha["ClienteDataNascimento"]);
            cliente.Numero = Convert.ToInt32(linha["ClienteNumero"]);
            cliente.Complemento = linha["ClienteComplemento"].ToString();
            cliente.Logradouro = linha["ClienteLogradouro"].ToString();
            cliente.Cep = linha["ClienteCEP"].ToString();

            cliente.Cidade = new Cidade();
            cliente.Cidade.Nome = linha["CidadeNome"].ToString();

            return cliente;
        }
        public bool Alterar(Cliente cliente)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"UPDATE clientes SET
id_cidade = @ID_CIDADE,
nome = @NOME,
cpf = @CPF,
data_nascimento = @DATA_NASCIMENTO,
numero = @NUMERO,
complemento = @COMPLEMENTO,
logradouro = @LOGRADOURO,
cep = @CEP
WHERE @ID = id";
            comando.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);
            comando.Parameters.AddWithValue("@ID", cliente.Id);

            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}


