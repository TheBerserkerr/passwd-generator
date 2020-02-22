
using PasswordGenerator.Analyze.Abstract;

namespace PasswordGenerator.Analyze
{
    public class DefaultAlphabet : IAlphabet
    {
        private string ll = "qwertyuiopasdfghjklzxcvbnm";
        private string ul = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private string d = "1234567890";
        private string s = ",./;[]|`~!@#$%^&*()_-+=>?<:{}";

        public string GetAlphabet(string key)
        {
            switch(key)
            {
                case "ll":
                    return ll;
                case "ul":
                    return ul;
                case "d":
                    return d;
                case "s":
                    return s;
                default:
                    return null;
            }
        }
    }
}