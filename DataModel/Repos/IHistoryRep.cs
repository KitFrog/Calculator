using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataModel.Entities;
using System.Threading.Tasks;

namespace DataModel.Repos
{
    public interface IHistoryRep
    {
        IQueryable<History> GetHistories(bool isGuest);
        IQueryable<History> GetHistoriesTop10(bool isGuest);
        Task<History> GetHistoryByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task AddAsync(History history);

    }
}
