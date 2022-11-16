using DataModel.Entities;
using DataModel.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataProviders.EFs.Core.Repos
{
    public class HistoryRep : IHistoryRep
    {
        public Task AddAsync(History history)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<History> GetHistories(bool isGuest)
        {
            throw new NotImplementedException();
        }

        public IQueryable<History> GetHistoriesTop10(bool isGuest)
        {
            throw new NotImplementedException();
        }

        public Task<History> GetHistoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
