using System.Text;

namespace CompilerTest
{
    /// <summary>
    /// 词
    /// </summary>
    public class Token
    {
        public TokenType TokenType { set; get; }
        public string Value { set; get; }
        public Token(TokenType type,string value)
        {
            TokenType = type;
            Value = value;
        }
        

    }
    public enum TokenType
    {
        /// <summary>
        /// 注释
        /// </summary>
        Annotation,
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
        /// 换行
        /// </summary>
        NewLine,
        /// <summary>
        /// 文件结束
        /// </summary>
        EendOfFile,
    }

   
}
