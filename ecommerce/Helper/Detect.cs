using System.Collections.Generic;

namespace ecommerce.Helper
{
    public static class Detect
    {
        private static readonly IList<string> censoredWords = new List<string>{
            "tonto"
        };

        public static string BadWords(string obj)
        {
            Censor censor = new Censor(censoredWords);
            return censor.CensorText(obj);
        }
    }
}
