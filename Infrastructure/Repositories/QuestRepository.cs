using Entities.Interfaces;
using Entities.Models;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        private readonly VillageContext _context;

        public QuestRepository(VillageContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quest>> GetAllAsync() => await _context.Quests.Include(s => s.Enrollments).ThenInclude(e => e.Warrior).AsNoTracking().ToListAsync();
        public async Task<Quest> GetByIdAsync(int id) => await _context.Quests.FindAsync(id);
        public async Task Insert(Quest quest) => await _context.Quests.AddAsync(quest);
        public async Task Remove(Quest quest) => _context.Remove(quest);
        public async Task Update(Quest quest) => _context.Quests.Update(quest);
    }
}
