using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Identificador
    {
        private string _token;
        private string _tipo;


        public string Token { get => _token; set => _token = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }

    }
}
