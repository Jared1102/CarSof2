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
        string codigoArduino = "", global = "#include <Servo.h>\r\n", setup = "\r\nvoid setup(){\r\n", loop = "}\r\n\r\nvoid loop(){\r\n", definicionFunction = "}\r\n";
        public string Traducir(List<ArbolSintactico> arbolSintacticos, List<string> pines)
        {
            global += "Servo servoMotor;\r\n";

            for (int i = 0; i < pines.Count-1; i++)
            {
                setup += string.Format("\tpinMode({0},OUTPUT);\r\n", pines[i]);
            }
            
            setup += string.Format("\tservoMotor.attach({0});\r\n\tSerial.begin(9600);\r\n", pines[pines.Count-1]);

            for (int i = 0; i < arbolSintacticos.Count; i++)
            {
                switch (arbolSintacticos[i].Nombre)
                {
                    case "Condición":
                        {
                            loop += "\t";
                            for (int j = 0; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                            {
                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                            }
                            loop += "\r\n";
                        }
                        break;
                    case "Declaración de variable":
                        {
                            for (int j = 0; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                            {
                                switch (arbolSintacticos[i].TokensLexicos[j].Tipo)
                                {
                                    case "Tipo de dato":
                                        {
                                            switch (arbolSintacticos[i].TokensLexicos[j].Texto)
                                            {
                                                case "*int":
                                                    {
                                                        global += "int ";
                                                    }break;
                                                case "*decimal":
                                                    {
                                                        global += "double ";
                                                    }
                                                    break;
                                                case "*string":
                                                    {
                                                        global += "char ";
                                                    }
                                                    break;
                                                case "*bool":
                                                    {
                                                        global = "#include <stdbool.h>\r\n" + global;
                                                        global += "bool ";
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "Identificador":
                                        {
                                            if (arbolSintacticos[i].TokensLexicos[j-1].Texto.Equals("*string"))
                                            {
                                                global += string.Format("{0}[]", arbolSintacticos[i].TokensLexicos[j].Texto);
                                            }
                                            else
                                            {
                                                global += string.Format("{0}", arbolSintacticos[i].TokensLexicos[j].Texto);
                                            }
                                        }break;
                                    case "Operador de asignación":
                                        {
                                            global += "=";
                                        }
                                        break;
                                    case "Valor numérico entero":
                                    case "Valor textual":
                                    case "Valor numérico decimal":
                                        {
                                            global+= arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        break;
                                    case "Valor booleano":
                                        {
                                            switch (arbolSintacticos[i].TokensLexicos[j].Texto)
                                            {
                                                case "T":
                                                    global += "true";
                                                break;
                                                case "F":
                                                    global += "false";
                                                    break;
                                            }
                                        }
                                        break;
                                    case "Separador de instrucción":
                                        {
                                            global += ";\r\n";
                                        }
                                        break;

                                }
                            }
                        }
                        break;
                    case "Expresión de asignación":
                        {
                            loop += "\t\t";
                            for (int j = 0; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                            {
                                switch (arbolSintacticos[i].TokensLexicos[j].Tipo)
                                {
                                    case "Identificador":
                                        {
                                            loop += string.Format("{0}", arbolSintacticos[i].TokensLexicos[j].Texto);
                                        }
                                        break;
                                    case "Operador de asignación":
                                        {
                                            loop += "=";
                                        }
                                        break;
                                    case "Valor textual":
                                    case "Valor numérico entero":
                                    case "Valor numérico decimal":
                                        {
                                            loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        break;
                                    case "Valor booleano":
                                        {
                                            switch (arbolSintacticos[i].TokensLexicos[j].Texto)
                                            {
                                                case "T":
                                                    loop += "true";
                                                    break;
                                                case "F":
                                                    loop += "false";
                                                    break;
                                            }
                                        }
                                        break;
                                    case "Separador de instrucción":
                                        {
                                            loop += ";\r\n";
                                        }
                                        break;

                                }
                            }
                        }
                        break;
                    case "Cierre de bloque":
                        {
                            loop += "\t}\r\n";
                        }
                        break;
                    case "Apertura de bloque":
                        {
                            loop+= "\t{\r\n";
                        }
                        break;
                    case "Instrucción": {
                            if (!global.Contains("#include <Car.h>"))
                            {
                                global = "#include <Car.h>\r\n" + global;
                                global += "Car car;";
                            }

                            switch (arbolSintacticos[i].TokensLexicos[0].Texto)
                            {
                                case "Run.Up":
                                    {
                                        loop += "\tcar.Up";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            if (j==1)
                                            {
                                                loop += string.Format("{0}{1},{2},{3},{4},{5},{6},",
                                                    arbolSintacticos[i].TokensLexicos[j].Texto,
                                                    pines[0],
                                                    pines[1],
                                                    pines[2],
                                                    pines[3],
                                                    pines[4],
                                                    pines[5]);
                                            }else
                                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                                case "Run.Stop":
                                    {
                                        loop += "\tcar.Stop";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            if (j == 1)
                                            {
                                                loop += string.Format("{0}{1},{2},{3},{4},{5},{6}",
                                                    arbolSintacticos[i].TokensLexicos[j].Texto,
                                                    pines[0],
                                                    pines[1],
                                                    pines[2],
                                                    pines[3],
                                                    pines[4],
                                                    pines[5]);
                                            }
                                            else
                                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                                case "On":
                                    {
                                        loop += "\tcar.On";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            if (j == 1)
                                            {
                                                loop += string.Format("{0}{1},{2}",
                                                    arbolSintacticos[i].TokensLexicos[j].Texto,
                                                    pines[0],
                                                    pines[3]);
                                            }
                                            else
                                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                                case "Off":
                                    {
                                        loop += "\tcar.Off";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            if (j == 1)
                                            {
                                                loop += string.Format("{0}{1},{2}",
                                                    arbolSintacticos[i].TokensLexicos[j].Texto,
                                                    pines[0],
                                                    pines[3]);
                                            }
                                            else
                                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                                case "Run.Turn":
                                    {
                                        loop += "\tcar.Turn";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            if (j == 1)
                                            {
                                                loop += string.Format("{0}{1},",
                                                    arbolSintacticos[i].TokensLexicos[j].Texto,
                                                    pines[6]);
                                            }
                                            else
                                                loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                                case "wait":
                                    {
                                        loop += "\tdelay";
                                        for (int j = 1; j < arbolSintacticos[i].TokensLexicos.Count; j++)
                                        {
                                            loop += arbolSintacticos[i].TokensLexicos[j].Texto;
                                        }
                                        loop += "\r\n";
                                    }
                                    break;
                            }

                        } break;
                }
            }

            codigoArduino = string.Format("{0}{1}{2}{3}", global,setup,loop,definicionFunction);

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
