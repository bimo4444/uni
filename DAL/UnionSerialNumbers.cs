using ADOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UnionSerialNumbers
    {
        ADO ado = new ADO();
        public int Union(string oldValues, string newValue)
        {
            int i = ado.Command("UPDATE ПозицияДокументаУчета SET НомерИзделия = " + newValue + "WHERE НомерИзделия in (" + oldValues + ");" +
                    "UPDATE БазовыйИзмерение SET СерийныйНомер = " + newValue + "WHERE СерийныйНомер in (" + oldValues + ");" +
                    "UPDATE ОбъектПланирования SET ItemNumber = " + newValue + "WHERE ItemNumber in (" + oldValues + ");" +
                    "UPDATE ОбъектПланирования SET НомерИзделия = " + newValue + "WHERE НомерИзделия in (" + oldValues + ");" +
                    "UPDATE ПДУ_СерийныеНомера SET СерийныеНомера = " + newValue + "WHERE СерийныеНомера in (" + oldValues + ");" +
                    "delete from СерийныйНомер where oid in (" + oldValues + ")");
            return i;
        }
    }
}
