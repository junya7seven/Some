using Application.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQuestService
    {
        Task<IEnumerable<Quest>> GetAllAsync();
        Task<Quest> GetByIdAsync(int id);
        Task<QuestDTO> CreateAsync(QuestDTO questDTO);
        Task UpdateAsync(int id, QuestDTO questDTO);
        Task DeleteAsync(int id);
    }
}
