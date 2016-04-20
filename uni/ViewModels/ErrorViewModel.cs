using MVPLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace uni.ViewModels
{
    public class ErrorViewModel : VMBase
    {
        public ICommand Back { get; set; }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
    }
}
