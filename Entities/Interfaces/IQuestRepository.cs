using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IQuestRepository
    {
        Task Insert(Quest quest);
        Task Remove(Quest quest);
        Task<Quest> GetByIdAsync(int id);
        Task<IEnumerable<Quest>> GetAllAsync();
        Task Update(Quest quest);
    }
}
