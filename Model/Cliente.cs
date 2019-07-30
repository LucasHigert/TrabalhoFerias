using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Cliente
    {
        public int Id;
        public int IdCidade;
        public int Numero;

        public string Cpf;
        public string Nome;
        public string Complemento;
        public string Logradouro;
        public string Cep;

        public DateTime DataNascimento;

        public Cidade Cidade;
    }
}
