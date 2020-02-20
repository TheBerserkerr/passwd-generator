
using System.Collections.Generic;
using PasswordGenerator.Analyze;
using PasswordGenerator.Analyze.Abstract;
using PasswordGenerator.Evaluating.Abstract;

namespace PasswordGenerator.Evaluating.Context
{
    public class InterpretingContext : IInterpretingContext
    {

        public IAlphabet Alphabet { get; private set; }

        private Dictionary<string, string> dictionary;

        public InterpretingContext()
        {
            dictionary = new Dictionary<string, string>();
            Alphabet = new DefaultAlphabet();
        }

        public InterpretingContext(IAlphabet alphabet)
        {
            dictionary = new Dictionary<string, string>();
            Alphabet = alphabet;
        }

        public object GetObject(object key)
        {
            if (dictionary.TryGetValue(key.ToString(), out string res))
                return res;

            return null;
        }

        public void SetObject(object key, object value)
        {
            dictionary.Add(key.ToString(), value.ToString());
        }
    }
}