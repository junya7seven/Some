using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IWarriorRepository
    {
        Task Insert(Warrior warrior);
        Task Remove(Warrior warrior);
        Task<Warrior> GetByIdAsync(int id);
        Task<IEnumerable<Warrior>> GetAllAsync();
        Task Update(Warrior warrior);
    }
}
