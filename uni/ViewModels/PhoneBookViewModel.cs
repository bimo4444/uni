using Entities;
using MVPLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace uni.ViewModels
{
    public class PhoneBookViewModel : VMBase
    {
        public ICommand Copy { get; set; }
        public ICommand Back { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee SelectedItem { get; set; }
    }
}
