
using System.Collections.Generic;
using PasswordGenerator.Analyze.Expression;

namespace PasswordGenerator.Analyze.Abstract
{
    public interface ICommandResolver
    {
        List<BaseExpression> Resolve();
    }
}