using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string _textToSplit = string.Empty;
        public string TextToSplit
        {
            get { return _textToSplit; }
            set
            {
                if (value == _textToSplit)
                    return;
                _textToSplit = value;
                PropertyChanged.Raise(() => TextToSplit);
            }
        }

        private Dictionary<string, int> _breakdown = new Dictionary<string, int>();
        public Dictionary<string, int> Breakdown
        {
            get { return _breakdown; }
            set
            {
                if (value == _breakdown)
                    return;
                _breakdown = value;
                PropertyChanged.Raise(() => Breakdown);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void ProcessText()
        {
            Dictionary<string, int> sorted = new Dictionary<string, int>();

            string[] words = this.TextToSplit.RemovePunctuation().Split(new char[] { ' ' });

            foreach (var word in words)
                if (word.Trim() != string.Empty)
                    sorted.AddOrIncrement(word.Trim());

            this.Breakdown = sorted;

        }
    }
}
