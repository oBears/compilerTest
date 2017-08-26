using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace CompilerTest
{
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
                        if (m.Groups[3].Success)
                        {
                            Tokens.Add(new Token(TokenType.Number, m.Groups[3].Value));
                        }//匹配字符串
                        if (m.Groups[4].Success)
                        {
                            Tokens.Add(new Token(TokenType.Number, m.Groups[4].Value));
                        }//匹配标识符
                        if (m.Groups[6].Success)
                        {
                            Tokens.Add(new Token(TokenType.Number, m.Groups[6].Value));
                        }
                    }
                }
                Tokens.Add(new Token(TokenType.NewLine, string.Empty));
            }
            Tokens.Add(new Token(TokenType.EendOfFile, string.Empty));
        }


    }
}
