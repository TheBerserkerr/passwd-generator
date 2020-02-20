
using PasswordGenerator.Analyze.Abstract;

namespace PasswordGenerator.Evaluating.Abstract
{
    public interface IInterpretingContext
    {
        IAlphabet Alphabet { get; }

        object GetObject(object key);
        void SetObject(object key, object value);
    }
}