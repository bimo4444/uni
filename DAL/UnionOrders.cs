using ADOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UnionOrders
    {
        ADO ado = new ADO();
        public int Union(string oldValues, string newValue)
        {
            int i = ado.Command("UPDATE ПозицияДокументаУчета SET ЗаказНаГППолучатель = " + newValue + " WHERE ЗаказНаГППолучатель in (" + oldValues + ");" +
                    "UPDATE ПозицияДокументаУчета SET ЗаказНаГППоставщик = " + newValue + " WHERE ЗаказНаГППоставщик in (" + oldValues + ");" +
                    "UPDATE БазовыйИзмерение SET ЗаказНаГП = " + newValue + " WHERE ЗаказНаГП in (" + oldValues + ");");
            return i;
        }
    }
}
