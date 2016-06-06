using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PhoneBookReader
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            using(LinqDataContext linq = new LinqDataContext())
            {
                //list = linq.
                //list.Add(new Employee { Name = "test0", Machine = "ggggg" });
                //list.Add(new Employee { Name = "test1", Machine = "gg" });
                //list.Add(new Employee { Name = "test4", Machine = "g" });
                //list.Add(new Employee { Name = "test4", Machine = "44444444" });
            }
            return list;
        }
    }
}
