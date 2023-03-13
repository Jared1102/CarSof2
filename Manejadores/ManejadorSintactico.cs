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
        private List<ErroresSintacticos> _erroresSintacticos=new List<ErroresSintacticos>();
        private List<ArbolSintactico> _arbolesSintacticos= new List<ArbolSintactico>();
        private int contador;
        private bool parametros = true;
        private int separador = 0;
        private bool operadorAsignacion;


        public List<ArbolSintactico> HacerSintactico(List<TokensLexico> tokens, DataGridView tabla)
        {
            _erroresSintacticos.Clear();
            _arbolesSintacticos.Clear();
            ArbolSintactico arbolSintactico=null;
            contador = 0;

            //Juntar tokens para las instrucciones
            List<TokensLexico> tokensLexicos=new List<TokensLexico>();

            for (int i = 0; i < tokens.Count; i++)
            {
                tokensLexicos.Add(tokens[i]);
                if (tokens[i].Tipo.Equals("Cierre de parametros") && tokensLexicos[0].Tipo.Equals("Condicional"))
                {
                    sintaxisCondicional(tokensLexicos);
                    arbolSintactico = new ArbolSintactico()
                    {
                        Nombre = "Condición",
                        TokensLexicos = tokensLexicos.ToList()
                    };
                    tokensLexicos.Clear();
                }
                else if (tokens[i].Tipo.Equals("Separador de instrucción") || 
                    tokens[i].Tipo.Equals("Cierre de bloque")||
                    tokens[i].Tipo.Equals("Apertura de bloque"))
                {
                    switch (tokensLexicos[0].Tipo)
                    {
                        case "Tipo de dato":
                            sintaxisDeclararVariable(tokensLexicos);
                            arbolSintactico=new ArbolSintactico()
                            {
                                Nombre="Declaración de variable",
                                TokensLexicos=tokensLexicos.ToList()
                            };
                            tokensLexicos.Clear();
                            break;
                        case "Identificador":
                            sintaxisExpresionAsignacion(tokensLexicos);
                            arbolSintactico = new ArbolSintactico()
                            {
                                Nombre = "Expresión de asignación",
                                TokensLexicos = tokensLexicos.ToList()
                            };
                            tokensLexicos.Clear();
                            break;
                        
                        case "Cierre de bloque":
                            arbolSintactico = new ArbolSintactico()
                            {
                                Nombre = "Cierre de bloque",
                                TokensLexicos = tokensLexicos.ToList()
                            };
                            tokensLexicos.Clear();
                            break;
                        case "Apertura de bloque":
                            arbolSintactico = new ArbolSintactico()
                            {
                                Nombre = "Apertura de bloque",
                                TokensLexicos = tokensLexicos.ToList()
                            };
                            tokensLexicos.Clear();
                            break;
                        case "Valor booleano":
                        case "Valor textual":
                        case "Valor númerico entero":
                        case "Valor númerico decimal":
                        case "Operador aritmético":
                        case "Operador de comparación":
                        case "Operador de asignación":
                        case "Apertura de parametros":
                        case "Cierre de parametros":
                        case "Separador":
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "La expresión utilizada no coincide con alguna instrucción posible",
                                Id = contador,
                                Linea = tokensLexicos[0].Linea.ToString(),
                                Recomendacion = "Reformular instrucción",
                                Token = tokensLexicos[0].Texto
                            });
                            tokensLexicos.Clear();
                            break;
                        case "Instrucción":
                            sintaxisInstrucciones(tokensLexicos);
                            arbolSintactico = new ArbolSintactico()
                            {
                                Nombre = "Instrucción",
                                TokensLexicos= tokensLexicos.ToList()
                            };
                            tokensLexicos.Clear();
                            break;
                    }
                }

                if (arbolSintactico!=null)
                {
                    _arbolesSintacticos.Add(arbolSintactico);
                    arbolSintactico= null;
                }

                if (contador>0)
                {
                    i=tokens.Count-1;
                    _arbolesSintacticos.Clear();
                }
            }

            if (tokensLexicos.Count>0)
            {
                contador++;
                _erroresSintacticos.Add(new ErroresSintacticos()
                {
                    Error = "Se esperaba un ;",
                    Id = contador,
                    Linea = tokensLexicos[tokensLexicos.Count-1].Linea.ToString(),
                    Recomendacion = "Agregar un ;",
                    Token = tokensLexicos[tokensLexicos.Count-1].Texto
                });
                _arbolesSintacticos.Clear();
            }

            tabla.DataSource = _erroresSintacticos.ToList();
            return _arbolesSintacticos.ToList();
        }

        private void sintaxisInstrucciones(List<TokensLexico> tokensLexicos)
        {
            switch (tokensLexicos[0].Texto)
            {
                case "Run.Up":
                    {
                        sintaxisRunUp(tokensLexicos);
                    }
                    break;
                case "Run.Stop":
                case "On":
                case "Off":
                    {
                        sintaxisInstruccionesVacias(tokensLexicos);
                    }
                    break;
                case "Run.Turn":
                case "wait":
                    {
                        sintaxisInstruccionesUnParametro(tokensLexicos);
                    }
                    break;
                default:
                    break;
            }
        }

        private void sintaxisInstruccionesUnParametro(List<TokensLexico> tokensLexicos)
        {
            validarSintaxisInstruccionesUnParametro(tokensLexicos, 0);
        }

        private void validarSintaxisInstruccionesUnParametro(List<TokensLexico> tokensLexicos, int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Instrucción":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Apertura de parametros"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba una apertura de parametros",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar una apertura de parametros",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Apertura de parametros":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Operador aritmético":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Valor booleano":
                case "Valor textual":
                case "Valor numérico entero":
                case "Valor numérico decimal":
                case "Identificador":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Operador de comparación") || tokensLexicos[i + 1].Tipo.Equals("Cierre de parametros") ||
                            tokensLexicos[i + 1].Tipo.Equals("Operador de aritmético")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un operador de comparación, aritmético o un )",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un operador de comparación, aritmético o un )",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                default:
                    break;
            }

            validarSintaxisInstruccionesUnParametro(tokensLexicos, i + 1);
        }


        private void sintaxisInstruccionesVacias(List<TokensLexico> tokensLexicos)
        {
            validarInstruccionesVacias(tokensLexicos, 0);
        }

        private void validarInstruccionesVacias(List<TokensLexico> tokensLexicos, int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Instrucción":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Apertura de parametros"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba una apertura de parametros",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar una apertura de parametros",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Apertura de parametros":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Cierre de parametros")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Esta instrucción no requiere de parametros",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Retirar los parametros",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Cierre de parametros":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un ;",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Colocar un ;",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                default:
                    break;
            }

            validarInstruccionesVacias(tokensLexicos, i + 1);
        }


        private void sintaxisRunUp(List<TokensLexico> tokensLexicos)
        {
            parametros = true;
            separador = 0;

            validarSintaxisRunUp(tokensLexicos, 0);

            if (parametros)
            {
                contador++;
                _erroresSintacticos.Add(new ErroresSintacticos()
                {
                    Error = "Se esperaban 2 parametros",
                    Id = contador,
                    Linea = tokensLexicos[separador].Linea.ToString(),
                    Recomendacion = "Agregar una apertura de parametros",
                    Token = tokensLexicos[separador].Texto
                });
            }
        }

        public void validarSintaxisRunUp(List<TokensLexico> tokensLexicos, int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Instrucción":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Apertura de parametros"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba una apertura de parametros",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar una apertura de parametros",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Apertura de parametros":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Operador aritmético":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Valor booleano":
                case "Valor textual":
                case "Valor numérico entero":
                case "Valor numérico decimal":
                case "Identificador":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Operador de comparación") || tokensLexicos[i + 1].Tipo.Equals("Cierre de parametros") ||
                            tokensLexicos[i + 1].Tipo.Equals("Operador de aritmético") || tokensLexicos[i + 1].Tipo.Equals("Separador")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un operador de comparación, aritmético o un )",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un operador de comparación, aritmético o un )",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Separador":
                    {
                        separador = i;
                        parametros = false;
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                default:
                    break;
            }

            validarSintaxisRunUp(tokensLexicos, i+1);
        }

        private void sintaxisCondicional(List<TokensLexico> tokensLexicos)
        {
            validarSintaxisCondicional(tokensLexicos,0);
        }

        private void validarSintaxisCondicional(List<TokensLexico> tokensLexicos, int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Condicional":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Apertura de parametros"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba una apertura de parametros",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar una apertura de parametros",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Apertura de parametros":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;

                case "Valor booleano":
                case "Valor textual":
                case "Valor númerico entero":
                case "Valor númerico decimal":
                case "Identificador":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Operador de comparación") || tokensLexicos[i + 1].Tipo.Equals("Cierre de parametros") ||
                            tokensLexicos[i + 1].Tipo.Equals("Operador de aritmético")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un operador de comparación o un )",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un operador de comparación o un )",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
            }

            validarSintaxisCondicional(tokensLexicos, i + 1);
        }

        private void sintaxisExpresionAsignacion(List<TokensLexico> tokensLexicos)
        {
            operadorAsignacion = false;
            validarSintaxisExpresionAsignacion(tokensLexicos, 0);
        }

        private void validarSintaxisExpresionAsignacion(List<TokensLexico> tokensLexicos,int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Identificador":
                    {
                        if (operadorAsignacion)
                        {
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción") || tokensLexicos[i + 1].Tipo.Equals("Operador de asignación")
                            || tokensLexicos[i + 1].Tipo.Equals("Operador aritmético")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un ;, un Operador de asignación o aritmético",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador a la declaración de variable",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }
                        else
                        {
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción") || tokensLexicos[i + 1].Tipo.Equals("Operador de asignación")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un ; o un Operador de asignación",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador a la declaración de variable",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }


                    }
                    break;
                case "Operador de asignación":
                    {
                        if (!operadorAsignacion)
                        {
                            operadorAsignacion = true;
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un identificador o un valor",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador o un valor",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }
                        else
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "No se puede usar más de 1 vez el operador de asignación",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Retirar el operador de asignación",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Operador aritmético":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Valor booleano":
                case "Valor textual":
                case "Valor númerico entero":
                case "Valor númerico decimal":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Operador aritmético") || tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un operador aritmético o un ;",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un operador aritmético o un ;",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                default:
                    break;
            }

            validarSintaxisExpresionAsignacion(tokensLexicos, i + 1);
        }

        private void sintaxisDeclararVariable(List<TokensLexico> tokensLexicos)
        {
            operadorAsignacion=false;
            validarSintaxisDeclararVariable(tokensLexicos, 0);
        }

        private void validarSintaxisDeclararVariable(List<TokensLexico> tokensLexicos, int i)
        {
            if (i >= tokensLexicos.Count - 1) return;

            switch (tokensLexicos[i].Tipo)
            {
                case "Tipo de dato":
                    {
                        if (!tokensLexicos[i + 1].Tipo.Equals("Identificador"))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador a la declaración de variable",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Identificador":
                    {
                        if (operadorAsignacion)
                        {
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción") || tokensLexicos[i + 1].Tipo.Equals("Operador de asignación")
                            || tokensLexicos[i + 1].Tipo.Equals("Operador aritmético")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un ;, un Operador de asignación o aritmético",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador a la declaración de variable",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }
                        else
                        {
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción") || tokensLexicos[i + 1].Tipo.Equals("Operador de asignación")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un ; o un Operador de asignación",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador a la declaración de variable",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }


                    }
                    break;
                case "Operador de asignación":
                    {
                        if (!operadorAsignacion)
                        {
                            operadorAsignacion = true;
                            if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                            {
                                contador++;
                                _erroresSintacticos.Add(new ErroresSintacticos()
                                {
                                    Error = "Se esperaba un identificador o un valor",
                                    Id = contador,
                                    Linea = tokensLexicos[i].Linea.ToString(),
                                    Recomendacion = "Agregar un identificador o un valor",
                                    Token = tokensLexicos[i].Texto
                                });
                            }
                        }
                        else
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "No se puede usar más de 1 vez el operador de asignación",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Retirar el operador de asignación",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Operador aritmético":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Identificador") || tokensLexicos[i + 1].Tipo.Contains("Valor")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un identificador o un valor",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un identificador o un valor",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                case "Valor booleano":
                case "Valor textual":
                case "Valor númerico entero":
                case "Valor númerico decimal":
                    {
                        if (!(tokensLexicos[i + 1].Tipo.Equals("Operador aritmético") || tokensLexicos[i + 1].Tipo.Equals("Separador de instrucción")))
                        {
                            contador++;
                            _erroresSintacticos.Add(new ErroresSintacticos()
                            {
                                Error = "Se esperaba un operador aritmético o un ;",
                                Id = contador,
                                Linea = tokensLexicos[i].Linea.ToString(),
                                Recomendacion = "Agregar un operador aritmético o un ;",
                                Token = tokensLexicos[i].Texto
                            });
                        }
                    }
                    break;
                default:
                    break;
            }

            validarSintaxisDeclararVariable(tokensLexicos,i + 1);
        }
    }
}
