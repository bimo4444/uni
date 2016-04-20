using ADOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UnionConsignments
    {
        ADO ado = new ADO();
        public int Union(string oldValues, string newValue)
        {
            int i = ado.Command("UPDATE ПозицияДокументаУчета SET Партия = " + newValue + " WHERE Партия in (" + oldValues + ");" +
                    "UPDATE ПозицияДокументаУчета SET ПартияПриемник = " + newValue + " WHERE ПартияПриемник in (" + oldValues + ");" +
                    "UPDATE ПозицияДокументаУчета SET ПартияПолучатель = " + newValue + " WHERE ПартияПолучатель in (" + oldValues + ");" +
                    "UPDATE БазовыйИзмерение SET Партия = " + newValue + " WHERE Партия in (" + oldValues + ");" +
                    "UPDATE ПартияПозицииДУ SET Партия = " + newValue + " WHERE Партия in (" + oldValues + ");" +
                    "UPDATE НЗПДвижение SET ПартияДСЕ = " + newValue + " WHERE ПартияДСЕ in (" + oldValues + ");" +
                    "UPDATE ПозицияКомплектующихДУ SET Партия = " + newValue + " WHERE Партия in (" + oldValues + ");" +
                    "UPDATE ЗаданиеНаРаботу SET ПартияЗапуска = " + newValue + " WHERE ПартияЗапуска in (" + oldValues + ");" +
                    "DELETE FROM СпецификацияПартия WHERE oid in (" + oldValues + ");");
            return i;
        }
    }
}
