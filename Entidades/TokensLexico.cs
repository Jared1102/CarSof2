using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TokensLexico
    {
        private int _id;
        private string _texto;
        private string _tipo;
        private int _linea;

        public int Id { get => _id; set => _id = value; }
        public string Texto { get => _texto; set => _texto = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public int Linea { get => _linea; set => _linea = value; }
    }
}
