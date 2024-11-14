using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRepositoryManager
    {
        IEnrollmentRepository enrollmentRepository {  get; }
        IWarriorRepository warriorRepository { get; }
        IQuestRepository questRepository { get; }
        IUnitOfWork unitOfWork { get; }
    }
}
