using MVPLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace uni.ViewModels
{
    class MainViewModel : VMBase
    {
        private UserControl _currentView;
        public UserControl CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        private Cursor _cursorState;
        public Cursor CursorState
        {
            get
            {
                return _cursorState;
            }
            set
            {
                _cursorState = value;
                OnPropertyChanged("CursorState");
            }
        }
    }
}
