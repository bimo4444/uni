using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEngine
{
    //normalize guids
    public class Engine
    {
        UnionSerialNumbers unionNumbers = new UnionSerialNumbers();
        UnionOrders unionOrders = new UnionOrders();
        UnionConsignments unionConsignments = new UnionConsignments();
        DeleteWays deleteWays = new DeleteWays();
        ReturnDeleted returnDeleted = new ReturnDeleted();
        GuidNormalizer gNormalizer = new GuidNormalizer();
        NamesHelper nHelper = new NamesHelper();
        PhoneBookReader phoneBookReader = new PhoneBookReader();

        //get names
        public string CheckGuidsEthic(bool checkBreed, bool deleted, string oldValues, string newValue = null)
        {
            if (newValue != null)
                oldValues += "," + newValue;
            var v = gNormalizer.NormalizeToList(oldValues);
            if (v.Count() == 0)
                return "";
            string s = nHelper.GetNames(v, deleted);
            //check guids for unique type
            if (checkBreed && nHelper.Breed)
                return "";
            return s;
        }

        //queries
        public int Union(string oldValues, string newValue)
        {
            oldValues = gNormalizer.NormalizeToString(oldValues);
            newValue = gNormalizer.NormalizeToString(newValue);
            if(nHelper.Serials)
                return unionNumbers.Union(oldValues, newValue);
            if(nHelper.Documents)
                return unionOrders.Union(oldValues, newValue);
            if(nHelper.Consignments)
                return unionConsignments.Union(oldValues, newValue);
            return 0;
        }
        public string CheckWaysDocuments(string guids)
        {
            var v = gNormalizer.NormalizeToList(guids);
            return v != Enumerable.Empty<Guid>() ? nHelper.GetDocumentNames(v) : "";
        }
        public int DeleteWays(string oldValues)
        {
            oldValues = gNormalizer.NormalizeToString(oldValues);
            return deleteWays.Delete(oldValues);
        }
        public int ReturnDeleted(string oldValues)
        {
            oldValues = gNormalizer.NormalizeToString(oldValues);
            return returnDeleted.Return(oldValues);
        }

        public List<Employee> GetEmployees()
        {
            return phoneBookReader.GetEmployees();
        }
    }
}
