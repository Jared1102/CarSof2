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
        private int contador;
        private bool continuar=true;
        private TokensLexico _auxtokensLexico = null;
        public void HacerSintactico(List<TokensLexico> tokens, DataGridView tabla)
        {
            contador = 1;
            errosSintacticos.Clear();
            tabla.Columns.Clear();
            for (int i = 0; i < tokens.Count-1; i++)
            {
                switch (tokens[i].Tipo)
                {
                    case "Tipo de dato":
                        sintaxisTipoDeDato(tokens[i], tokens[i + 1]);
                    break;
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
                    case "Condicional":
                        sintaxisCondicional(tokens[i], tokens[i + 1]);
                        break;
                    case "Apertura de parametros":
                        sintaxisAperturaDeParametros(tokens[i], tokens[i+1]);
                        break;
                    case "Cierre de parametros":
                        sintaxisCierraDeParametros(tokens[i]);
                        break;
                    default:
                        break;
                }

                if (!continuar)
                {
                    i = tokens.Count - 1;
                }
            }

            if (_auxtokensLexico!=null && continuar)
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba )",
                    Id = contador,
                    Linea = _auxtokensLexico.Linea.ToString(),
                    Recomendacion = "Agregar un (",
                    Token = _auxtokensLexico.Texto
                });

                contador++;

                _auxtokensLexico = null;
            }

            if (errosSintacticos.Count>0)
            {
                tabla.DataSource = errosSintacticos.ToList();
            }
        }

        private void sintaxisCierraDeParametros(TokensLexico tokensLexico)
        {
            if (_auxtokensLexico==null)
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba (",
                    Id = contador,
                    Linea = tokensLexico.Linea.ToString(),
                    Recomendacion = "Agregar un (",
                    Token = tokensLexico.Texto
                });
                
                contador++;
                continuar = false;
            }
            _auxtokensLexico = null;

        }

        private void sintaxisAperturaDeParametros(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals(tokensLexico2.Tipo, "Identificador") && !tokensLexico2.Tipo.Contains("Valor"))
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
                continuar = false;
            }
            _auxtokensLexico = tokensLexico1;
        }

        private void sintaxisCondicional(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals(tokensLexico2.Tipo, "Apertura de parametros"))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba (",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un (",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
                continuar = false;
            }
        }

        private void sintaxisValor(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals("Operador aritmetico",tokensLexico2.Tipo) && 
                !string.Equals("Separador de instrucción",tokensLexico2.Tipo) && 
                !string.Equals("Cierre de parametros", tokensLexico2.Tipo) && 
                !string.Equals("Separador",tokensLexico2.Tipo))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un operador aritmetico, un ; o )",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un +,-,/,* o ;",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
                continuar = false;
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
                continuar = false;
            }
        }

        private void sintaxisIdentificador(TokensLexico tokensLexico1, TokensLexico tokensLexico2)
        {
            if (!string.Equals(tokensLexico2.Tipo, "Operador de asignación") && 
                !string.Equals(tokensLexico2.Tipo, "Separador de instrucción") && 
                !string.Equals(tokensLexico2.Tipo, "Operador de comparación") && 
                !string.Equals(tokensLexico2.Tipo,"Cierre de parametros") &&
                tokensLexico2.Tipo.Contains("Valor"))
            {
                errosSintacticos.Add(new ErroresSintacticos
                {
                    Error = "Se esperaba un ; o un operador",
                    Id = contador,
                    Linea = tokensLexico1.Linea.ToString(),
                    Recomendacion = "Agregar un ; o una asignación de valor",
                    Token = string.Format("{0} {1}", tokensLexico1.Texto, tokensLexico2.Texto)
                });
                contador++;
                continuar = false;
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
                continuar = false;
            }
        }
    }
}
