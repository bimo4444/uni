using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEngine
{
    class GuidNormalizer
    {
        public string NormalizeToString(string guids)
        {
            return "'" + guids.Replace(" ", "").Replace("{", "").Replace("}", "").Replace(",", "','") + "'";
        }
        public IEnumerable<Guid> NormalizeToList(string guids)
        {
            var list = guids.Replace(" ", "").Replace("{", "").Replace("}", "").Split(',');
            try
            {
                return list.Select(ss => Guid.Parse(ss)).ToList();
            }
            catch
            {
                return Enumerable.Empty<Guid>();
            }
        }
    }
}
