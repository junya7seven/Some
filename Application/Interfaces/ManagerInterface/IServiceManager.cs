using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceManager
    {
        IEnrollmentService EnrollmentService { get; }
        IQuestService QuestService { get; }
        IWarriorService WarriorService { get; }
    }
}
