using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ErroresSemanticos
    {
        private int _id;
        private string _error;

        public int Id { get => _id; set => _id = value; }
        public string Error { get => _error; set => _error = value; }
    }
}
