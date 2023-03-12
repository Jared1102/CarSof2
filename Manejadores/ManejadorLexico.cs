using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Manejadores
{
    public class ManejadorLexico
    {
        public List<TokensLexico> _tokens = new List<TokensLexico>();
        private int contador;
        public List<TokensLexico> HacerLexico(string codigo,DataGridView tabla)
        {
            
            _tokens.Clear();
            contador = 1;
            StringBuilder builder = new StringBuilder(codigo);
            builder.Replace("=", " = ")
                   .Replace("=  =", "==")
                   .Replace("!", " ! ")
                   .Replace("!  =", "!=")
                   .Replace(">", " > ")
                   .Replace("<", " < ")
                   .Replace(">  =", ">=")
                   .Replace("<  =", "<=")
                   .Replace("(", " ( ")
                   .Replace(")", " ) ")
                   .Replace(",", " , ")
                   .Replace(";", " ; ")
                   .Replace("+", " + ")
                   .Replace("-", " - ")
                   .Replace("*", " * ")
                   .Replace("/", " / ")
                   .Replace("* int", "*int")
                   .Replace("* decimal", "*decimal")
                   .Replace("* string", "*string")
                   .Replace("* bool", "*bool");

            codigo = builder.ToString();
            
            string[] lineas = codigo.Split('\n');
            AgregarLineas(lineas, 0);


            tabla.DataSource= _tokens.ToList();
            return _tokens;
        }
        private void AgregarLineas(string[] lineas, int i)
        {
            if (i >= lineas.Length) return;
            if (lineas[i].Contains("#"))
            {
                string comentario = lineas[i].Substring(0, lineas[i].IndexOf("#"));
                if (!string.IsNullOrWhiteSpace(comentario))
                {
                    string[] tnt = comentario.Split(' ');
                    AgregarTokensRecursivo(tnt, 0, i + 1);
                }
            }
            else if (!string.IsNullOrWhiteSpace(lineas[i]))
            {
                string[] tnt = lineas[i].Split(' ');
                AgregarTokensRecursivo(tnt, 0, i + 1);
            }
            AgregarLineas(lineas, i + 1);
        }

        private void AgregarTokensRecursivo(string[] tnt, int index, int linea)
        {
            if (index == tnt.Length)
                return;

            if (!string.IsNullOrWhiteSpace(tnt[index]))
            {
                _tokens.Add(generarToken(contador, tnt[index], linea));
                contador++;
            }

            AgregarTokensRecursivo(tnt, index + 1, linea);
        }

        private TokensLexico generarToken(int i1, string v, int i2)
        {
            return new TokensLexico
            {
                Id= i1,
                Linea=i2,
                Texto=v,
                Tipo=identificarTipo(v)
            };
        }

        private string identificarTipo(string v)
        {
            string[] tipoDato = { "*int", "*decimal", "*string", "*bool" };
            string[] instrucciones = { "Run.Up", "Run.Stop", "Run.Turn", "On", "Off", "wait" };
            string[] operadorAritmetico = { "+", "-", "/", "*" };
            string[] operadorComparacion = { "==", "!=", ">", "<", ">=", "<=" };

            if (tipoDato.Contains(v))
            {
                return "Tipo de dato";
            }else if(v.Equals("T") || v.Equals("F"))
            {
                return "Valor booleano";
            }
            else if(v.Equals("if")){
                return "Condicional";
            }else if (instrucciones.Contains(v))
            {
                return "Instrucción";
            }
            else if (identificarIdentificador(v))
            {
                return "Identificador";
            }else if (operadorAritmetico.Contains(v))
            {
                return "Operador aritmético";
            }else if (operadorComparacion.Contains(v))
            {
                return "Operador de comparación";
            }
            else if (v.Equals("="))
            {
                return "Operador de asignación";

            }
            else if (v.Equals(";"))
            {
                return "Separador de instrucción";
            }
            else if (v.Contains("("))
            {
                return "Apertura de parametros";
            }
            else if (v.Contains(")"))
            {
                return "Cierre de parametros";
            }
            else if (v.Contains("$$"))
            {
                return "Cierre de bloque";
            }
            else if (v.Contains("$"))
            {
                return "Apertura de bloque";
            }
            else if (v.Contains(","))
            {
                return "Separador";
            }else if (identificarValorTextual(v))
            {
                return "Valor textual";
            }
            else if (identificarValorEntero(v))
            {
                return "Valor númerico entero";
            }
            else if (identificarValorDecimal(v))
            {
                return "Valor númerico decimal";
            }
            else
            {
                return "No identificado";
            }
        }

        private bool identificarValorDecimal(string v)
        {
            return Regex.IsMatch(v, @"^[0-9]\d*(\.\d+)?$");
        }

        private bool identificarValorTextual(string v)
        {
            return Regex.IsMatch(v, "\"[^\"\\\\]*(?:\\\\.[^\"\\\\]*)*\"");
        }

        private bool identificarValorEntero(string v)
        {
            return Regex.IsMatch(v, @"^[0-9]*$");
        }

        private bool identificarIdentificador(string v)
        {
            return Regex.IsMatch(v, @"^[A-Za-z]+?");
        }
    }
}
