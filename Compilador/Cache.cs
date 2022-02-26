using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador
{
    public class Cache
    {
        public static Cache Instance { get; private set; }
        public IDictionary<int, string> TheDictionary { get; private set; }
        
        private Cache()
        {
            TheDictionary = new Dictionary<int, string>();
        }
        public static Cache GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Cache();
            }
            return Instance;
        }
        public void AgregarValoresDiccionario(Linea linea)
        {
            TheDictionary.Add(linea.lineaNumero, linea.lineaTexto);
        }
    }
}
