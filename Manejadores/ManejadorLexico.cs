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
        public List<TokensLexico> HacerLexico(string codigo,DataGridView tabla)
        {
            int contador = 1;
            _tokens.Clear();
            codigo = codigo.Replace("=", " = ");
            codigo=codigo.Replace("=  =", "==");
            codigo = codigo.Replace("(", " ( ");
            codigo = codigo.Replace(")", " ) ");
            codigo = codigo.Replace(",", " , ");
            codigo = codigo.Replace(";", " ; ");
            codigo = codigo.Replace("+", " + ");
            codigo = codigo.Replace("-", " - ");
            codigo = codigo.Replace("*", " * ");
            codigo = codigo.Replace("/", " / ");
            codigo = codigo.Replace("* int", "*int");
            codigo = codigo.Replace("* decimal", "*decimal");
            codigo = codigo.Replace("* string", "*string");
            codigo = codigo.Replace("*bool", "bool");

            string[] lineas = codigo.Split('\n');

            for (int i = 0; i < lineas.Length; i++)
            {
                if (Regex.IsMatch(lineas[i],"#"))
                {
                    string[] comentario = Regex.Split(lineas[i], "#");
                    if (!string.IsNullOrEmpty(comentario[0]) && !string.IsNullOrWhiteSpace(comentario[0]) && comentario[0]!=null)
                    {
                        string[] tnt = comentario[0].Split(' ');
                        for (int j = 0; j < tnt.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(tnt[j]) && !string.IsNullOrWhiteSpace(tnt[j]))
                            {
                                _tokens.Add(generarToken(contador, tnt[j], i + 1));
                                contador++;
                            }
                            
                        }
                        
                    }
                    /*_tokens.Add(new TokensLexico
                    {
                        Id= i,
                        Linea=i+1,
                        Texto= "#"+ comentario[1],
                        Tipo="Comentario"
                    });*/
                }else if (!string.IsNullOrEmpty(lineas[i]) && !string.IsNullOrWhiteSpace(lineas[i]))
                {
                    string[] tnt = lineas[i].Split(' ');
                    for (int j = 0; j < tnt.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(tnt[j]) && !string.IsNullOrWhiteSpace(tnt[j]))
                        {
                            _tokens.Add(generarToken(contador, tnt[j], i + 1));
                            contador++;
                        }
                    }
                }
                
            }

            tabla.DataSource= _tokens.ToList();
            return _tokens;
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
                return "Operador aritmetico";
            }else if (operadorComparacion.Contains(v))
            {
                return "Operador de comparación";
            }
            else if (v.Equals("="))
            {
                return "Operador de asignación";

            }
            else if (v.Contains(";"))
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
