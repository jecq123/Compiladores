using System;

namespace Compilador
{
    public class Line
    {
        private static Line line;
        private int lineNumber;
        private String lineText;

        private Line() { }

        public static Line GetInstance()
        {
            if (line == null) line = new Line();
            return line;
        }

        public void SetLineValues(int lineNumber, string lineText)
        {
            this.lineNumber = lineNumber;
            this.lineText = lineText;
        }

        public int GetLineNumber()
        {
            return lineNumber;
        }

        public string GetLineText()
        {
            return lineText;
        }
    }
}
