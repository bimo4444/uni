using ADOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ReturnDeleted
    {
        ADO ado = new ADO();
        public int Return(string guid)
        {
            string name = System.Environment.UserName;
            string time = DateTime.Now.ToString();
            int i = ado.Command("update НоменклатурнаяПозиция set GCRecord = null, ИзмененПользователем = '" + name + "', ДатаПоследнейМодификации = '" + time + "' where GCRecord is not null and Oid in (" + guid + ");" +
                "update СерийныйНомер set GCRecord = null, ИзмененПользователем = '" + name + "', ДатаПоследнейМодификации = '" + time + "' where GCRecord is not null and Oid in (" + guid + ");" +
                "update СпецификацияПартия set GCRecord = null, ИзмененПользователем = '" + name + "', ДатаПоследнейМодификации = '" + time + "' where GCRecord is not null and Oid in (" + guid + ");" +
                "update Документ set GCRecord = null, ИзмененПользователем = '" + name + "', ДатаПоследнейМодификации = '" + time + "' where GCRecord is not null and Oid in (" + guid + ");");
            return i;
        }
    }
}
