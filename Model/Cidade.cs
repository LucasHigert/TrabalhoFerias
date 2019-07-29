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

        //Propriedade para a coluna do id_Estado(FK)
        public int IdEstado;

        /*Objeto da estado que permitirá acessar as 
         * informações de estado através da cidade.
         */
        public Estado Estado;

        public string Nome;
        public int NumeroHabitantes;
    }
}
