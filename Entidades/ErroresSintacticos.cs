using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ErroresSintacticos
    {
        private int _id;
        private string _token;
        private string _linea;
        private string _Error;
        private string _Recomendacion;

        public int Id { get => _id; set => _id = value; }
        public string Token { get => _token; set => _token = value; }
        public string Error { get => _Error; set => _Error = value; }
        public string Recomendacion { get => _Recomendacion; set => _Recomendacion = value; }
        public string Linea { get => _linea; set => _linea = value; }
    }
}
