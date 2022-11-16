using DataModel.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DataManager
    {
        public IHistoryRep HistoryRep { get; }

        public DataManager(IHistoryRep historyRep)
        {
            HistoryRep = historyRep;
        }
    }
}
