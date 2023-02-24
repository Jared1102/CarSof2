using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSemantico
    {
        private List<ErroresSemanticos> _erroresSemanticos;
        private int _contadorBloque,_contadorErrores;
        private bool _apagado;
        private List<Identificador> _identificadores;
        public void HacerSemantica(List<ArbolSintactico> arbolSintacticos,DataGridView tabla, List<TokensLexico> tokensLexicos)
        {
            _identificadores= new List<Identificador>();
            _identificadores.Clear();
            _apagado = false;
            _contadorBloque = 0;
            _contadorErrores = 0;
            _erroresSemanticos = new List<ErroresSemanticos>();
            _erroresSemanticos.Clear();
            for (int i = 0; i < arbolSintacticos.Count; i++)
            {
                switch (arbolSintacticos[i].Nombre)
                {
                    case "Apertura de bloque":
                        {
                            if (_contadorBloque<0)
                            {
                                _contadorErrores++;
                                _erroresSemanticos.Add(new ErroresSemanticos()
                                {
                                    Error = "Cuando se requiera un bloque de codigo, siempre se utiliza primero la apertura de bloque",
                                    Id = _contadorErrores
                                });
                                i = arbolSintacticos.Count;
                            }
                            _contadorBloque++;
                        }
                        break;
                    case "Cierre de bloque":
                        {
                            _contadorBloque--;
                        }
                        break;
                    case "Instrucción":
                        {
                            if (_apagado)
                            {
                                switch (arbolSintacticos[i].TokensLexicos[0].Texto)
                                {
                                    case "On":
                                        {
                                            _apagado = false;
                                        }
                                        break;
                                    default:
                                        {
                                            if (!arbolSintacticos[i].TokensLexicos[0].Texto.Equals("wait"))
                                            {
                                                _contadorErrores++;
                                                _erroresSemanticos.Add(new ErroresSemanticos()
                                                {
                                                    Error = "Solo las instrucciones wait y on pueden ejecutarse despues de un off",
                                                    Id = _contadorErrores
                                                });
                                                i = arbolSintacticos.Count;
                                            }
                                        }
                                        break;
                                }
                                
                                
                            }
                            else
                            {
                                switch (arbolSintacticos[i].TokensLexicos[0].Texto)
                                {
                                    case "Off":
                                        {
                                            _apagado = true;
                                        }
                                        break;
                                }
                            }
                            
                        }
                        break;
                }
            }

            if (_contadorBloque != 0)
            {
                _contadorErrores++;
                _erroresSemanticos.Add(new ErroresSemanticos()
                {
                    Error="El numero de aperturas y cierre de bloque no coincide",
                    Id=_contadorErrores
                });
            }

            //Revisar existencia identificadores
            revisarDeclaracionIdentificadores(arbolSintacticos);

            revisarIdentificadores(tokensLexicos);

            //Revisar funciones
            revisarFunciones(arbolSintacticos);

            tabla.DataSource = _erroresSemanticos.ToList();
        }

        private void revisarFunciones(List<ArbolSintactico> arbolSintacticos)
        {
            for (int i = 0; i < arbolSintacticos.Count; i++)
            {
                switch (arbolSintacticos[i].Nombre)
                {
                    case "Condición":
                        {
                            revisarSemanticaCondicion(arbolSintacticos[i].TokensLexicos);
                        }
                        break;
                    case "Instrucción":
                        {
                            revisarSemanticaInstruccion(arbolSintacticos[i].TokensLexicos);
                        }break;
                    default:
                        break;
                }
            }
        }

        private void revisarSemanticaInstruccion(List<TokensLexico> tokensLexicos)
        {
            switch (tokensLexicos[0].Texto)
            {
                case "Run.Up":
                    {
                        switch (tokensLexicos[2].Tipo)
                        {
                            case "Valor booleano":
                            case "Valor textual":
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "El parametro 1 de Run.Up solo admite valores numericos",
                                        Id = _contadorErrores
                                    });
                                }
                                break;
                            case "Identificador":
                                {
                                    for (int j = 0; j < _identificadores.Count; j++)
                                    {
                                        if (_identificadores[j].Token.Equals(tokensLexicos[2].Texto))
                                        {
                                            switch (_identificadores[j].Tipo)
                                            {
                                                case "Valor booleano":
                                                case "Valor textual":
                                                    {
                                                        _contadorErrores++;
                                                        _erroresSemanticos.Add(new ErroresSemanticos()
                                                        {
                                                            Error = "El parametro 1 de Run.Up solo admite valores numericos",
                                                            Id = _contadorErrores
                                                        });
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        switch (tokensLexicos[4].Tipo)
                        {
                            case "Valor booleano":
                            case "Valor númerico entero":
                            case "Valor númerico decimal":
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "El parametro 2 de Run.Up solo admite valores textuales",
                                        Id = _contadorErrores
                                    });
                                }
                                break;
                            case "Valor textual":
                                {
                                    if (!(tokensLexicos[4].Texto.Equals("\"front\"") || tokensLexicos[4].Texto.Equals("\"back\"")))
                                    {
                                        _contadorErrores++;
                                        _erroresSemanticos.Add(new ErroresSemanticos()
                                        {
                                            Error = "El parametro 2 de Run.Up solo admite \"front\" ó \"back\"",
                                            Id = _contadorErrores
                                        });
                                    }
                                }
                            break;
                            case "Identificador":
                                {
                                    for (int j = 0; j < _identificadores.Count; j++)
                                    {
                                        if (_identificadores[j].Token.Equals(tokensLexicos[4].Texto))
                                        {
                                            switch (_identificadores[j].Tipo)
                                            {
                                                case "Valor booleano":
                                                case "Valor númerico entero":
                                                case "Valor númerico decimal":
                                                    {
                                                        _contadorErrores++;
                                                        _erroresSemanticos.Add(new ErroresSemanticos()
                                                        {
                                                            Error = "El parametro 2 de Run.Up solo admite valores textuales",
                                                            Id = _contadorErrores
                                                        });
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void revisarSemanticaCondicion(List<TokensLexico> tokensLexicos)
        {
            string tipoDato = "";
            for (int i = 0; i < tokensLexicos.Count; i++)
            {
                switch (tokensLexicos[i].Tipo)
                {
                    case "Identificador":
                        {
                            for (int j = 0; j < _identificadores.Count; j++)
                            {
                                if (tipoDato=="" && _identificadores[j].Token.Equals(tokensLexicos[i].Texto))
                                {
                                    tipoDato = _identificadores[j].Tipo;
                                }
                                else if (tipoDato!="" && _identificadores[j].Token.Equals(tokensLexicos[i].Texto))
                                {
                                    if (tipoDato != _identificadores[j].Tipo)
                                    {
                                        _contadorErrores++;
                                        _erroresSemanticos.Add(new ErroresSemanticos()
                                        {
                                            Error = "La comparación solo se permite entre mismos tipos de valor",
                                            Id = _contadorErrores
                                        });
                                    }
                                }
                            }
                        }
                                break;
                    case "Valor booleano":
                        {
                            if (tipoDato=="")
                            {
                                tipoDato = "Valor booleano";
                            }
                            else
                            {
                                if (tipoDato != tokensLexicos[i].Tipo)
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "La comparación solo se permite entre mismos tipos de valor",
                                        Id = _contadorErrores
                                    });
                                }
                            }
                        }
                        break;
                    case "Valor textual":
                        {
                            if (tipoDato == "")
                            {
                                tipoDato = "Valor textual";
                            }
                            else
                            {
                                if (tipoDato != tokensLexicos[i].Tipo)
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "La comparación solo se permite entre mismos tipos de valor",
                                        Id = _contadorErrores
                                    });
                                }
                            }
                        }
                        break;
                    case "Valor númerico entero":
                        {
                            if (tipoDato == "")
                            {
                                tipoDato = "Valor númerico entero";
                            }
                            else
                            {
                                if (tipoDato != tokensLexicos[i].Tipo)
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "La comparación solo se permite entre mismos tipos de valor",
                                        Id = _contadorErrores
                                    });
                                }
                            }
                        }
                        break;
                    case "Valor númerico decimal":
                        {
                            if (tipoDato == "")
                            {
                                tipoDato = "Valor númerico decimal";
                            }
                            else
                            {
                                if (tipoDato != tokensLexicos[i].Tipo)
                                {
                                    _contadorErrores++;
                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                    {
                                        Error = "La comparación solo se permite entre mismos tipos de valor",
                                        Id = _contadorErrores
                                    });
                                }
                            }
                        }
                        break;
                    case "Operador de comparación":
                        {
                            switch (tipoDato)
                            {
                                case "Valor booleano":
                                    {
                                        switch (tokensLexicos[i].Texto)
                                        {
                                            case ">":
                                            case "<":
                                            case ">=":
                                            case "<=":
                                                {
                                                    _contadorErrores++;
                                                    _erroresSemanticos.Add(new ErroresSemanticos()
                                                    {
                                                        Error = string.Format("No se puede aplicar el operador {0} en esta expresión", tokensLexicos[i].Texto),
                                                        Id = _contadorErrores
                                                    });
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void revisarIdentificadores(List<TokensLexico> tokensLexicos)
        {
            bool encontrado=false;
            for (int i = 0; i < tokensLexicos.Count; i++)
            {
                if (tokensLexicos[i].Tipo.Equals("Identificador"))
                {
                    for (int j = 0; j < _identificadores.Count; j++)
                    {
                        if (_identificadores[j].Token.Equals(tokensLexicos[i].Texto))
                        {
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        _contadorErrores++;
                        _erroresSemanticos.Add(new ErroresSemanticos()
                        {
                            Error = string.Format("El identificador {0} no se encuentra en el contexto actual", tokensLexicos[i].Texto),
                            Id = _contadorErrores
                        });
                    }
                    encontrado= false;
                }
            }
        }

        private void revisarDeclaracionIdentificadores(List<ArbolSintactico> arbolSintacticos)
        {
            for (int i = 0; i < arbolSintacticos.Count; i++)
            {
                if (arbolSintacticos[i].Nombre.Equals("Declaración de variable"))
                {
                    _identificadores.Add(new Identificador()
                    {
                        Token = arbolSintacticos[i].TokensLexicos[1].Texto,
                        Tipo = identificarValor(arbolSintacticos[i].TokensLexicos[0].Texto),
                    });
                }
            }
        }

        private string identificarValor(string texto)
        {
            switch (texto)
            {
                case "*int": return "Valor númerico entero";
                case "*decimal": return "Valor númerico decimal";
                case "*string": return "Valor textual";
                case "*bool": return "Valor booleano";
            }

            return texto;
        }
    }
}