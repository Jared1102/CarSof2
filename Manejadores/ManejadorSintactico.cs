using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSintactico
    {
        private List<ErroresSintacticos> errosSintacticos=new List<ErroresSintacticos>();
        private List<TokensLexico> instruccion = new List<TokensLexico>();
        private int contador = 1;
        public void HacerSintactico(List<TokensLexico> tokens, DataGridView tabla)
        {
            errosSintacticos.Clear();
            tabla.Columns.Clear();
            for (int i = 0; i < tokens.Count-1; i++)
            {
                switch (tokens[i].Tipo)
                {
                    case "Tipo de dato": sintaxisTipoDeDato(tokens[i], tokens[i + 1]); break;
                    case "Identificador":
                        sintaxisIdentificador(tokens[i], tokens[i + 1]); break;
                    case "Operador de asignación":
                        sintaxisAsignacion(tokens[i], tokens[i + 1]); break;
                    case "Valor booleano":
                    case "Valor textual":
                    case "Valor númerico entero":
                    case "Valor númerico decimal":
                        sintaxisValor(tokens[i], tokens[i + 1]);
                        break;
                    default:
                        break;
                }
            }

            if (errosSintacticos.Count>0)
            {
                tabla.DataSource = errosSintacticos.ToList();
            }
        }

        private void sintaxisValor(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals("Operador aritmetico",tokensLexico2.Tipo) && !string.Equals("Separador de instrucción",tokensLexico2.Tipo) && !string.Equals("Cierre de parametros", tokensLexico2.Tipo) && !string.Equals("Separador",tokensLexico2.Tipo))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un operador aritmetico o un ;",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un +,-,/,* o ;",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
            }
        }

        private void sintaxisAsignacion(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals("Identificador",tokensLexico2.Tipo) && !tokensLexico2.Tipo.Contains("Valor"))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un identificador o un valor",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un identificador o valor",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
            }
        }

        private void sintaxisIdentificador(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals(tokensLexico2.Tipo, "Operador de asignación") && !string.Equals(tokensLexico2.Tipo, "Separador de instrucción") && !string.Equals(tokensLexico2.Tipo, "Operador de comparación"))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un ; o una asignación de valor",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un ; o una asignación de valor",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
            }
        }

        private void sintaxisTipoDeDato(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals(tokensLexico2.Tipo, "Identificador"))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un identificador en la declaración de variable",
                    Id=contador,
                    Linea=tokensLexico1.Linea.ToString(),
                    Recomendacion="Agregar un identificador",
                    Token=string.Format("{0} {1}",tokensLexico1.Texto,tokensLexico2.Texto)
                });
                contador++;
            }
        }
    }
}
