using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest
{
    public static class DictionaryExt
    {
        public static void AddOrIncrement(this Dictionary<string, int> that, string key)
        {
            if (that.ContainsKey(key))
            {
                that[key]++;
            }
            else
            {
                that[key] = 1;
            }
        }
    }
}
