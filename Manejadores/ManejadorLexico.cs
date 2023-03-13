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
                   .Replace("* bool", "*bool")
                   .Replace("\r","");

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
            HashSet<string> tipoDato = new HashSet<string>(new string[] { "*int", "*decimal", "*string", "*bool" });
            HashSet<string> instrucciones = new HashSet<string>(new string[] { "Run.Up", "Run.Stop", "Run.Turn", "On", "Off", "wait" });
            HashSet<string> operadorAritmetico = new HashSet<string>(new string[] { "+", "-", "/", "*" });
            HashSet<string> operadorComparacion = new HashSet<string>(new string[] { "==", "!=", ">", "<", ">=", "<=" });

            switch (v)
            {
                case "T":
                case "F":
                    return "Valor booleano";
                case "if":
                    return "Condicional";
                case "=":
                    return "Operador de asignación";
                case ";":
                    return "Separador de instrucción";
                case ",":
                    return "Separador";
                case "(":
                    return "Apertura de parametros";
                case ")":
                    return "Cierre de parametros";
                case "$":
                    return "Apertura de bloque";
                case "$$":
                    return "Cierre de bloque";
                default:
                    if (tipoDato.Contains(v))
                    {
                        return "Tipo de dato";
                    }
                    else if (instrucciones.Contains(v))
                    {
                        return "Instrucción";
                    }
                    else if (identificarIdentificador(v))
                    {
                        return "Identificador";
                    }
                    else if (operadorAritmetico.Contains(v))
                    {
                        return "Operador aritmético";
                    }
                    else if (operadorComparacion.Contains(v))
                    {
                        return "Operador de comparación";
                    }
                    else if (identificarValorTextual(v))
                    {
                        return "Valor textual";
                    }
                    else if (identificarValorEntero(v))
                    {
                        return "Valor numérico entero";
                    }
                    else if (identificarValorDecimal(v))
                    {
                        return "Valor numérico decimal";
                    }
                    else
                    {
                        return "No identificado";
                    }
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
