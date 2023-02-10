using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArbolSintactico
    {
        private string _nombre;
        private List<TokensLexico> _tokensLexicos;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<TokensLexico> TokensLexicos { get => _tokensLexicos; set => _tokensLexicos = value; }
    }
}
