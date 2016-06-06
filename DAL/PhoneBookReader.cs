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
            }
            return list;
        }
    }
}
