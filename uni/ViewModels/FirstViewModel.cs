using MVPLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace uni.ViewModels
{
    public class FirstViewModel : VMBase
    {
        public ICommand Union { get; set; }
        public ICommand Ways { get; set; }
        public ICommand Return { get; set; }
        public ICommand ShowPhoneBook { get; set; }

        private string _oldValues;
        public string OldValues
        {
            get { return _oldValues; }
            set
            {
                _oldValues = value;
                OnPropertyChanged("OldValues");
            }
        }

        private string _newValue;
        public string NewValue
        {
            get { return _newValue; }
            set
            {
                _newValue = value;
                OnPropertyChanged("NewValue");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
    }
}
