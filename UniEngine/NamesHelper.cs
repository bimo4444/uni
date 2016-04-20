﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEngine
{
    //get queries
    //check guid types
    //check when more then one type
    //transformates strings for views

    class NamesHelper
    {
        private bool b;
        public bool Breed { get; private set; }
        public bool Nomenclatures { get; private set; }
        public bool Consignments { get; private set; }
        public bool Documents { get; private set; }
        public bool Serials { get; private set; }

        Names n = new Names();

        public string GetDocumentNames(IEnumerable<Guid> guids)
        {
            IEnumerable<string> s = n.GetDocumentNames(guids);
            return s != null ? "\nДокументы:" + StringJoin(s) : "";
        }

        public string GetNames(IEnumerable<Guid> guids)
        {
            b = Breed = Nomenclatures =
                Consignments = Documents = Serials = false;

            string s = "";
            IEnumerable<string> ss;

            ss = n.GetConsignmentNames(guids);
            if (ss != null)
            {
                s += "\nПартии:" + StringJoin(ss);
                b = true;
                Consignments = true;
                ss = null;
            }

            ss = n.GetDocumentNames(guids);
            if (ss != null)
            {
                s += "\nДокументы:" + StringJoin(ss);
                ChechBreed();
                Documents = true;
                ss = null;
            }

            ss = n.GetNomenclatureNames(guids);
            if (ss != null)
            {
                s += "\nНП:" + StringJoin(ss);
                ChechBreed();
                Nomenclatures = true;
                ss = null;
            }

            ss = n.GetSerialNames(guids);
            if (ss != null)
            {
                s += "\nСерийные номера:" + StringJoin(ss);
                ChechBreed();
                Serials = true;
                ss = null;
            }

            return s;
        }
        private string StringJoin(IEnumerable<string> ls)
        {
            return "\n" + string.Join("\n", ls.ToArray());
        }
        private void ChechBreed()
        {
            if (b)
                Breed = true;
            else
                b = true;
        }
    }
}
