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
        String,
        /// <summary>
        /// 行结束
        /// </summary>
        EendOfLine,
        /// <summary>
        /// 文件结束
        /// </summary>
        EendOfFile,
    }

    public class NumberToken : Token
    {
        public int Value { set; get; }
        public NumberToken(int lineNumber,int val) : base(lineNumber)
        {
            TokenType = TokenType.Number;
            Value = val;
        }
    }

    public class StringToken : Token
    {
        public string Value { set; get; }
        public StringToken(int lineNumber,string val) : base(lineNumber)
        {
            TokenType = TokenType.String;
            Value = val;
        }
    }

    public class IdentifierToken : Token
    {
        public string Value { set; get; }
        public IdentifierToken(int lineNumber,string val) : base(lineNumber)
        {
            TokenType = TokenType.Identifier;
            Value = val;
        }
    }

    public class EOFToken : Token
    {
        public EOFToken() : base(-1)
        {
            TokenType = TokenType.EendOfFile;
        }
    }
    public class EOLToken : Token
    {
        public EOLToken(int lineNumber) : base(lineNumber)
        {
            TokenType = TokenType.EendOfLine;
        }
    }






    /// <summary>
    /// 词法分析器
    /// </summary>
    public class Lexer
    {
        public List<Token> Tokens = new List<Token>();
        private const string regexPat = @"\s*((//.*)|([0-9]+)|(""(\\""|\\\\|\\n|[^\""])*"")|([a-zA-Z]+[a-zA-Z0-9]*|[~!@#\$%\^&\*\(\)\+=\|\}\]\{\[:;<,>\?]+))";
        private StreamReader _r;

        public Lexer(StreamReader reader)
        {
            _r = reader;
        }
        public void Run()
        {
            var lineNumber = 0;
            while (!_r.EndOfStream)
            {
                var line = _r.ReadLine();
                var matches = Regex.Matches(line, regexPat);
                for (int i = 0; i < matches.Count; i++)
                {
                    var m = matches[i];
                    if (m.Success)
                    {
                        //匹配注释  
                        if (m.Groups[2].Success)
                        {
                            //不做处理

                        }//匹配数字
                        else if (m.Groups[3].Success)
                        {
                            Tokens.Add(new NumberToken(lineNumber, Convert.ToInt32(m.Groups[3].Value)));
                        }//匹配字符串
                        else if (m.Groups[4].Success)
                        {
                            Tokens.Add(new StringToken(lineNumber,m.Groups[4].Value));
                        }//匹配标识符
                        else if (m.Groups[6].Success)
                        {
                            Tokens.Add(new IdentifierToken(lineNumber,m.Groups[6].Value));
                        }

                    }
                }

                Tokens.Add(new EOLToken(lineNumber));
                lineNumber++;
            }
            Tokens.Add(new EOFToken());
        }


    }
}
