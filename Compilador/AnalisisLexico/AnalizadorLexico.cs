using System;
using System.Collections.Generic;
using System.Text;
using CompiladorClase.Cache;
using CompiladorClase.Trasnversal;

namespace CompiladorClase.AnalisisLexico
{
    class AnalizadorLexico
    {
        private int numeroLineaActual;
        private int apuntador;
        private String caracterActual;
        private String contenidoLineaActual;
        private AnalizadorLexico()
        {
            cargarNuevaLinea();
        }

        public static AnalizadorLexico crear()
        {
            return new AnalizadorLexico();
        }

        private void cargarNuevaLinea()
        {
            numeroLineaActual += 1;
            Linea lineaActual = ProgramaFuente.obtenerProgramaFuente().obtenerLinea(numeroLineaActual);
            contenidoLineaActual = lineaActual.obtenerContenido();
            numeroLineaActual = lineaActual.obtenerNumeroLinea();
            apuntador = 1;
        }

        private void leerSiguienteCaracter()
        {

            if (CategoriaGramatical.FIN_ARCHIVO.Equals(contenidoLineaActual))
            {
                caracterActual = CategoriaGramatical.FIN_ARCHIVO;
            }
            else if (apuntador > contenidoLineaActual.Length)
            {
                caracterActual = CategoriaGramatical.FIN_LINEA;
                apuntador++;
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring(apuntador - 1, 1);
                apuntador++;
            }
        }
        private void devolverPuntero()
        {
            apuntador--;
        }

        private bool esIgual(String cadena,String cadena2)
        {
            if (cadena == null && cadena2 == null)
            {
                return true;
            }
            else if (cadena == null)
            {
                return false;
            }
            return cadena.Equals(cadena2);
        }
        private bool esLetra()
        {
            return Char.IsLetter(caracterActual.ToCharArray()[0]);
        }
        private bool esDigito()
        {
            return Char.IsDigit(caracterActual.ToCharArray()[0]);
        }
        private bool esPesos()
        {
            return "$".Equals(caracterActual);
        }

        private bool esGuionBajo()
        {
            return "_".Equals(caracterActual);
        }

        private bool esFinLinea()
        {
            return esIgual(CategoriaGramatical.FIN_LINEA, caracterActual);
        }
        private bool esComa()
        {
            return ",".Equals(caracterActual);
        }
        private bool esSuma()
        {
            return "+".Equals(caracterActual);
        }
        private bool esResta()
        {
            return "-".Equals(caracterActual);
        }
        private bool esMultiplicacion()
        {
            return "*".Equals(caracterActual);
        }
        private bool esDivision()
        {
            return "/".Equals(caracterActual);
        }
        private bool esAsterizco()
        {
            return "*".Equals(caracterActual);
        }
        private bool esModulo()
        {
            return "%".Equals(caracterActual);
        }
        private bool esParentecisAbre()
        {
            return "(".Equals(caracterActual);
        }
        private bool esParentecisCierra()
        {
            return ")".Equals(caracterActual);
        }
        private bool esIgual()
        {
            return "=".Equals(caracterActual);
        }
        private bool esMenorQue()
        {
            return "<".Equals(caracterActual);
        }
        private bool esMayorQue()
        {
            return "<".Equals(caracterActual);
        }
        private bool esDiferente()
        {
            return "!".Equals(caracterActual);
        }
        private bool esDosPuntos()
        {
            return ":".Equals(caracterActual);
        }


        public ComponenteLexico devolderSiguienteComponente()
        {
            ComponenteLexico retorno= null;
            int estadoactual = 0;
            string lexema = "";
            bool continuarAnalisis=true;
            while (continuarAnalisis)
            {
                if (estadoactual == 0)
                {
                    leerSiguienteCaracter();
                    while(" ".Equals(caracterActual))
                    {
                        leerSiguienteCaracter();
                    }
                    if (esLetra()||esPesos()||esGuionBajo())
                    {
                        estadoactual = 4;
                        lexema = lexema + caracterActual;
                    }
                    else if (esDigito())
                    {
                        estadoactual = 1;
                        lexema = lexema + caracterActual;
                    }
                    else if (esSuma())
                    {
                        estadoactual = 5;
                        lexema = lexema + caracterActual;
                    }
                    else if (esResta())
                    {
                        estadoactual = 6;
                        lexema = lexema + caracterActual;
                    }
                    else if (esMultiplicacion())
                    {
                        estadoactual = 7;
                        lexema = lexema + caracterActual;
                    }
                    else if (esDivision())
                    {
                        estadoactual = 8;
                    }
                    else if (esModulo())
                    {
                        estadoactual = 9;
                        lexema = lexema + caracterActual;
                    }
                    else if (esParentecisAbre())
                    {
                        estadoactual = 10;
                        lexema = lexema + caracterActual;
                    }
                    else if (esParentecisCierra())
                    {
                        estadoactual = 11;
                        lexema = lexema + caracterActual;
                    }
                    else if (CategoriaGramatical.FIN_ARCHIVO.Equals(caracterActual))
                    {
                        estadoactual = 12;
                    }
                    else if (esIgual())
                    {
                        estadoactual = 19;
                        lexema = lexema + caracterActual;
                    }
                    else if (esMenorQue())
                    {
                        estadoactual = 20;
                        lexema = lexema + caracterActual;
                    }
                    else if (esMayorQue())
                    {
                        estadoactual = 21;
                        lexema = lexema + caracterActual;
                    }
                    else if (esDosPuntos())
                    {
                        estadoactual = 22;
                        lexema = lexema + caracterActual;
                    }
                    else if (esDiferente())
                    {
                        estadoactual = 30;
                        lexema = lexema + caracterActual;
                    }
                    else if (esFinLinea())
                    {
                        estadoactual = 13;
                    }
                    else
                    {
                        estadoactual = 18;
                    }
                }
                else if (estadoactual == 1)
                {
                    leerSiguienteCaracter();
                    if (esDigito())
                    {
                        estadoactual = 1;
                        lexema = lexema + caracterActual;
                    }
                    else if (esComa())
                    {
                        estadoactual = 2;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 14;
                    }

                }
                else if (estadoactual == 2)
                {
                    leerSiguienteCaracter();
                    if (esDigito())
                    {
                        estadoactual = 3;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 17;
                    }

                }
                else if (estadoactual == 3)
                {
                    leerSiguienteCaracter();
                    if (esDigito())
                    {
                        lexema = lexema + caracterActual;
                        estadoactual = 3;
                    }
                    else
                    {
                        estadoactual = 15;
                    }

                }
                else if (estadoactual == 4)
                {
                    leerSiguienteCaracter();
                    if (esLetra() || esDigito() || esGuionBajo() || esPesos())
                    {
                        estadoactual = 4;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 16;
                    }
                }
                else if (estadoactual == 5)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.SUMA, lexema);
                }
                else if (estadoactual == 6)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.RESTA, lexema);

                }
                else if (estadoactual == 7)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MULTIPLICACION, lexema);
                }
                else if (estadoactual == 8)
                {
                    leerSiguienteCaracter();
                    if(esAsterizco())
                    {
                        estadoactual = 34;

                    }
                    else if(esDivision())
                    {
                        estadoactual = 36;
                    }
                    else
                    {
                       estadoactual = 33;
                    }

                }
                else if (estadoactual == 9)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MODULO, lexema);

                }
                else if (estadoactual == 10)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.PARENTESIS_ABRE, lexema);
                }
                else if (estadoactual == 11)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.PARENTESIS_CIERRA, lexema);
                }
                else if (estadoactual == 12)
                {
                    //Revisar que hacer con el fin de archivo @EOF@
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.FIN_ARCHIVO, lexema);

                }
                else if (estadoactual == 13)
                {
                    cargarNuevaLinea();
                    estadoactual = 0;
                }
                else if (estadoactual == 14)
                {
                    continuarAnalisis = false;
                    devolverPuntero();
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.ENTERO, lexema);

                }
                else if (estadoactual == 15)
                {
                    continuarAnalisis = false;
                    devolverPuntero();
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.DECIMAL, lexema);

                }
                else if (estadoactual == 16)
                {
                    continuarAnalisis = false;
                    devolverPuntero();
                    
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1,CategoriaGramatical.IDENTIFICADOR,lexema);

                }
                else if (estadoactual == 17)
                {
                    //falta gestor de errores
                    continuarAnalisis = false;
                    devolverPuntero();
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.DECIMAL, lexema + "0");
                }
                else if (estadoactual == 18)
                {
                    throw new Exception("Error critico de tipo lexico: Se detuvo el analisis!!!!");
                }
                else if (estadoactual == 19)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.IGUAL, lexema);
                }
                else if (estadoactual == 20)
                {
                    leerSiguienteCaracter();
                    if(esMayorQue())
                    {
                        estadoactual = 23;
                        lexema = lexema + caracterActual;
                    }
                    else if(esIgual())
                    {
                        estadoactual = 24;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 25;
                    }
                }
                else if (estadoactual == 21)
                {
                    leerSiguienteCaracter();
                    if (esIgual())
                    {
                        estadoactual = 26;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 27;
                    }

                }
                else if (estadoactual == 22)
                {
                    leerSiguienteCaracter();
                    if (esIgual())
                    {
                        estadoactual = 28;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 29;
                    }

                }
                else if (estadoactual == 23)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.DIFERENTE_QUE, lexema);
                }
                else if (estadoactual == 24)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MENOR_O_IGUAL_QUE, lexema);
                }
                else if (estadoactual == 25)
                {
                    devolverPuntero();
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MENOR_QUE, lexema);
                }
                else if (estadoactual == 26)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MAYOR_O_IGUAL_QUE, lexema);

                }
                else if (estadoactual == 27)
                {
                    devolverPuntero();
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.MAYOR_QUE, lexema);
                }
                else if (estadoactual == 28)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.ASIGNAION, lexema);

                }
                else if (estadoactual == 29)
                {
                    throw new Exception("Error asignacion no valido!!!!");

                }
                else if (estadoactual == 30)
                {
                    leerSiguienteCaracter();
                    if (esIgual())
                    {
                        estadoactual = 31;
                        lexema = lexema + caracterActual;
                    }
                    else
                    {
                        estadoactual = 32;
                    }
                }
                else if (estadoactual == 31)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.DIFERENTE_QUE, lexema);

                }
                else if (estadoactual == 32)
                {
                    throw new Exception("Error asignacion no valida!!!!");
                }
                else if (estadoactual == 33)
                {
                    continuarAnalisis = false;
                    devolverPuntero();
                    lexema = "/";
                    retorno = ComponenteLexico.crear(numeroLineaActual, apuntador - lexema.Length, apuntador - 1, CategoriaGramatical.DIVISION, lexema);
                }
                else if (estadoactual == 34)
                {
                    leerSiguienteCaracter();
                    if (esAsterizco())
                    {
                        estadoactual = 35;
                    }
                    else if(CategoriaGramatical.FIN_LINEA.Equals(caracterActual))
                    {
                        estadoactual = 37;
                    }
                    else if (CategoriaGramatical.FIN_ARCHIVO.Equals(caracterActual))
                    {
                        estadoactual = 38;
                    }
                    else
                    {
                        estadoactual = 34;
                    }

                }
                else if (estadoactual == 35)
                {
                    leerSiguienteCaracter();
                    if (esAsterizco())
                    {
                        estadoactual = 35;
                    }
                    else if(CategoriaGramatical.FIN_LINEA.Equals(caracterActual))
                    {
                        estadoactual = 37;
                    }
                    else if (CategoriaGramatical.FIN_ARCHIVO.Equals(caracterActual))
                    {
                        estadoactual = 38;
                    }
                    else if (esDivision())
                    {
                        estadoactual = 0;
                    }
                    else
                    {
                        estadoactual = 34;
                    }

                }
                else if (estadoactual == 36)
                {
                    leerSiguienteCaracter();
                    if (CategoriaGramatical.FIN_LINEA.Equals(caracterActual))
                    {
                        estadoactual = 13;
                    }
                    else if (CategoriaGramatical.FIN_ARCHIVO.Equals(caracterActual))
                    {
                        //tenemos pendientes este analisis
                    }

                }
                else if (estadoactual == 37)
                {
                    cargarNuevaLinea();
                    estadoactual = 34;
                }
                else if (estadoactual == 38)
                {
                    throw new Exception("Comentario no cerrado!!!!");
                }

            }
            return retorno;
        }
    }
}
