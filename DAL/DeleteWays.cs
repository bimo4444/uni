using ADOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DeleteWays
    {
        ADO ado = new ADO();
        public int Delete(string guids)
        {
            int i = ado.Command("delete w from ВПутиДвижение w join БазовыйДокументУчета d on w.Регистратор = d.Oid where (d.ТипДокументаУчета = 0 and d.ДокументИсточник in (" +
                    guids + ")) or (d.ТипДокументаУчета = 6 and d.Oid in (" + guids + "))");
            return i;
        }
    }
}
