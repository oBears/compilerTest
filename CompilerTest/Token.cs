using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace CompilerTest
{
    /// <summary>
    /// 词
    /// </summary>
    public class Token
    {
        public static Token EOF = new Token(-1);
        public static string EOL = "\\n";
        public int LineNumber { get; private set; }
        public Token(int lineNumber)
        {
            LineNumber = lineNumber;
        }
        public TokenType TokenType { set; get; }
    }
    public enum TokenType
    {
        /// <summary>
        /// 标识符
        /// </summary>
        Identifier,
        /// <summary>
        /// 整型字面量
        /// </summary>
        Number,
        /// <summary>
        /// 字符串字面量
        /// </summary>
        String
    }

    public class NumberToken : Token
    {
        public NumberToken(int lineNumber) : base(lineNumber)
        {
            TokenType = TokenType.Number;
        }
    }

    public class StringToken : Token
    {
        public StringToken(int lineNumber) : base(lineNumber)
        {
            TokenType = TokenType.String;
        }
    }

    public class IdentifierToken : Token
    {
        public IdentifierToken(int lineNumber) : base(lineNumber)
        {
            TokenType = TokenType.Identifier;
        }
    }






    /// <summary>
    /// 词法分析器
    /// </summary>
    public class Lexer
    {
        public static string CommentPat = @"//.*";
        public static string NumberPat = @"[0-9]+";
        //    \p{Punct} 匹配标点符号：!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ 
        public static string IdentifierPat = @"[a-zA-Z][a-zA-Z0-9]*|==|<=|>=|&&|\|\||\p{Punct}";
        //  与\"、\\、\n或除"之外任意一个字符匹配
        public static string StringPat = @"""(\\""|\\\\|\\n|[^\""])*""";
        public static string RegexPat = $"\\s*(({CommentPat})|({NumberPat})|({StringPat})|{IdentifierPat})?";
        private List<Token> Tokens = new List<Token>();
        public void ReadLine()
        {
           


        }


    }
}
