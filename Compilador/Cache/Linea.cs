using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorClase.Cache
{
    class Linea
    {
        private int numeroLinea;
        private String contenido;

        private Linea(int numeroLinea, string contenido)
        {
            this.contenido = contenido;
            this.numeroLinea = numeroLinea;
        }

        public static Linea crear(int numeroLinea, string contenido)
        {
            return new Linea(numeroLinea, contenido);
        }
        public int obtenerNumeroLinea()
        {
            return numeroLinea;
        }

        public String obtenerContenido()
        {
            return contenido;
        }
    }
}
