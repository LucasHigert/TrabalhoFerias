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
        public int Numero;
        public string Nome;
        public string Cpf;
        public string Cep;
        public string Logradouro;
        public string Complemento;
        public DateTime DataNascimento;


        public int IdCidade;
        public Cidade Cidade;
    }
}
