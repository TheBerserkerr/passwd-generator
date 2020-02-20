using System.Collections.Generic;


namespace PasswordGenerator.Analyze.Expression
{
    public class GenExpression : BaseExpression
    {
        public int Length { get; set; }
        public List<string> Alphabets { get; set; }
    }
}