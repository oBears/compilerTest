using System;
using System.IO;

namespace CompilerTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var reader = new FileInfo("test.txt").OpenText();
            var lex = new Lexer(reader);
            lex.Run();

           
        }
    }
}