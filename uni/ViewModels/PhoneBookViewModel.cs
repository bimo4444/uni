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
        private List<Employee> employees;
        public List<Employee> Employees 
        { 
            get { return employees; } 
            set 
            { 
                employees = value;
                OnPropertyChanged("Employees");
            }
        }
        public Employee SelectedItem { get; set; }
    }
}
