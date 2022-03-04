using System.Collections.Generic;

namespace Compilador
{
    public class Cache
    {
        private static Cache cache;
        private IDictionary<int, string> linesDictionary;
        
        private Cache()
        {
            linesDictionary = new Dictionary<int, string>();
        }
        public static Cache GetInstance()
        {
            if (cache == null)
            {
                cache = new Cache();
            }
            return cache;
        }

        public IDictionary<int, string> GetLinesDictionary()
        {
            return linesDictionary;
        }
        public void AddNewLine(Line line)
        {
            linesDictionary.Add(line.GetLineNumber(), line.GetLineText());
        }

        public void AddLines(string[] lines)
        {
            Line line = Line.GetInstance();
            int numberLine = 1;
            foreach (string lineText in lines)
            {
                
                line.SetLineValues(numberLine, lineText);
                cache.AddNewLine(line);
                numberLine++;
            }
        }

        public void Reset()
        {
            linesDictionary.Clear();
        }
    }
}
