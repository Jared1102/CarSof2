using Entidades;
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
        public string Traducir(List<TokensLexico> _listTokens,List<string> pines)
        {
            string global = "#include <Servo.h>\r\n", setup = "\r\nvoid setup(){\r\n", loop= "}\r\n\r\nvoid loop(){\r\n", definicionFunction= "}\r\n";

            global += "Servo servoMotor;\r\n";

            for (int i = 0; i < pines.Count-1; i++)
            {
                setup += string.Format("\tpinMode({0},OUTPUT);\r\n", pines[i]);
            }
            
            setup += string.Format("\tservoMotor.attach({0});\r\n\tSerial.begin(9600);\r\n", pines[pines.Count-1]);

            string codigoArduino = string.Format("{0}{1}{2}{3}", global,setup,loop,definicionFunction);

            return codigoArduino;
        }
        public void SubirIno(string codigo, int placa, string puerto)
        {
            File.WriteAllText("test.ino", codigo);
            File.WriteAllText("compilar.bat", string.Format("@echo off\nArduinoUpLoader {0} test.ino {1}",
                (placa + 1).ToString(),
                puerto));
        }
    }
}
