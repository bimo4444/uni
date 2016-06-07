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
                list = linq.SecuritySystemUsers
                    .Where(w => w.GCRecord == null && (w.Примечание != null || w.Компьютер != null))
                    .OrderBy(o => o.ФИО)
                    .Select(s => new Employee
                    {
                        Name = s.ФИО,
                        Phone = s.Примечание,
                        Machine = s.Компьютер
                    })
                    .ToList();
            }
            return list;
        }
    }
}
