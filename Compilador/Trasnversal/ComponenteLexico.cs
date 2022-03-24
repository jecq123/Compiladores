using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorClase.Trasnversal
{
    class ComponenteLexico
    {
        public int numeroLinea;
        private int posicionFinal;
        private int posicionInicial;
        private String categoria;
        private String lexema;

        private ComponenteLexico(int numeroLinea, int posicionInicial, int posicionFinal, string categoria, string lexema)
        {
            this.numeroLinea = numeroLinea;
            this.posicionFinal = posicionFinal;
            this.posicionInicial = posicionInicial;
            this.categoria = categoria;
            this.lexema = lexema;
        }

        public static ComponenteLexico crear(int numeroLinea, int posicionInicial, int posicionFinal, string categoria, string lexema)
        {
            return new ComponenteLexico(numeroLinea, posicionInicial, posicionFinal, categoria, lexema);
        }

        public int obtenerNumeroLinea()
        {
            return numeroLinea;
        }

        public int obtenerPosicionInicial()
        {
            return posicionInicial;

        }
        public int obtenerPosicionFinal()
        {
            return posicionFinal;

        }

        public string obtenerCategoria()
        {
            return categoria;
        }

        public string obtenerLexema()
        {
            return lexema;
        }

        public String formarComponente()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Categoria: ").Append(categoria).Append("\n");
            sb.Append("Lexema: ").Append(lexema).Append("\n");
            sb.Append("Numero Linea: ").Append(numeroLinea).Append("\n");
            sb.Append("Posicion inicial: ").Append(posicionInicial).Append("\n");
            sb.Append("Posicion final: ").Append(posicionFinal).Append("\n");

            return sb.ToString();
        }

    }
}
