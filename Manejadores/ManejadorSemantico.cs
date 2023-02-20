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
        public void HacerSemantica(List<ArbolSintactico> arbolSintacticos,DataGridView tabla)
        {
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



            tabla.DataSource = _erroresSemanticos.ToList();
        }
    }
}