using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Cidade
    {
        public int Id;
        public string Nome;
        public string Cpf;
        public DateTime DataNascimento;
        public int Numero;
        public string Complemento;
        public string Logradouro;
        public string Cep;

        //Propriedade para a coluna do id_Estado(FK)
        public int IdEstado;

        /*Objeto da estado que permitirá acessar as 
         * informações de estado através da cidade.
         */
        public Estado Estado;
    }
}
