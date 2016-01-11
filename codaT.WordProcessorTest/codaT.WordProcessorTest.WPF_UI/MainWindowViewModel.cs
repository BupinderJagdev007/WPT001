using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codaT.WordProcessorTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindowModel _model = null;

        public MainWindowViewModel()
        {
            this._model = new MainWindowModel();
            this._model.PropertyChanged += _model_PropertyChanged;
        }

        void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("TextToSplit", StringComparison.OrdinalIgnoreCase))
                ((DelegateCommand)_processTextCommand).RaiseCanExecuteChanged();                    
        }

        public MainWindowModel Model
        {
            get { return _model; }
            private set 
            { 
                if (value == _model)
                    return;
                _model = value;
                PropertyChanged.Raise(() => Model);
            }
        }

        private ICommand _processTextCommand;
        public ICommand ProcessTextCommand
        {
            get
            {
                if (null == _processTextCommand)
                    _processTextCommand = new DelegateCommand(
                        _ => this.Model.ProcessText(), 
                        _ => !string.IsNullOrEmpty(this.Model.TextToSplit));

                return _processTextCommand;                                        
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
