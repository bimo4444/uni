using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Names
    {
        public IEnumerable<string> GetDocumentNames(IEnumerable<Guid> guids)
        {
            using (LinqDataContext l = new LinqDataContext())
            {
                return l.Документs.Where(w => guids.Contains(w.Oid) && w.GCRecord == null).Select(s => s.СтроковоеПредставление).ToList();
            }
        }
        public IEnumerable<string> GetSerialNames(IEnumerable<Guid> guids)
        {
            using (LinqDataContext l = new LinqDataContext())
            {
                return l.СерийныйНомерs.Where(w => guids.Contains(w.Oid) && w.GCRecord == null).Select(s => s.Номер).ToList();
            }
        }
        public IEnumerable<string> GetNomenclatureNames(IEnumerable<Guid> guids)
        {
            using (LinqDataContext l = new LinqDataContext())
            {
                return l.НоменклатурнаяПозицияs.Where(w => guids.Contains(w.Oid) && w.GCRecord == null).Select(s => s.СтроковоеПредставление).ToList();
            }
        }
        public IEnumerable<string> GetConsignmentNames(IEnumerable<Guid> guids)
        {
            using (LinqDataContext l = new LinqDataContext())
            {
                return l.СпецификацияПартияs.Where(w => guids.Contains(w.Oid) && w.GCRecord == null).Select(s => s.Партия).ToList();
            }
        }
    }
}
