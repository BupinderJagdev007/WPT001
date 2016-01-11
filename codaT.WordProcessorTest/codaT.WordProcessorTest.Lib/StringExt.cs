using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest
{
    public static class StringExt
    {
        // this is quick a dirty
        public const string SIMPLE_COMMA_FULLSTOP = ", ." ; 
        // this is much slower
        public const string COMPLEX_ALL = ", . ! \" £ $ % ^ & * ( ) - _ + = [ ] { } : < > ? / \\ | @ ;";

        public static string RemovePunctuation(this string that, string punctuationToRemove = COMPLEX_ALL)
        {
            string[] toRemove = punctuationToRemove.Split(new char[] { ' ' });

            foreach (var remove in toRemove)
                that = that.Replace(remove, " ");

            return that;
        }
    }
}
