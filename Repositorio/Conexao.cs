using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Conexao
    {
        public static SqlCommand Conectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            return comando;
        }
    }
}

/*tabelas
 * usuário - ok
 * categorias - ok
 * --------------------------
 * estados - ok
 * cidades - ok
 * clientes -
 * projetos - 
 * -------------------------
 * tarefas - 
 */
 
