using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejadores
{
    public class ManejadorTraductor
    {
        public void Traducir(string codigo, int placa, string puerto)
        {
            File.WriteAllText("test.ino", codigo);
            File.WriteAllText("compilar.bat", string.Format("@echo off\nArduinoUpLoader {0} test.ino {1}",
                (placa + 1).ToString(),
                puerto));
        }
    }
}
