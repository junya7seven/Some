using Application.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEnrollmentService> _lazyEnrollmentService;
        private readonly Lazy<IQuestService> _lazyQuestService;
        private readonly Lazy<IWarriorService> _lazyWarriorService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyEnrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(repositoryManager));
            _lazyQuestService = new Lazy<IQuestService>(() => new QuestService(repositoryManager));
            _lazyWarriorService = new Lazy<IWarriorService>(() => new WarriorService(repositoryManager));
        }

        public IEnrollmentService EnrollmentService => _lazyEnrollmentService.Value;
        public IQuestService QuestService => _lazyQuestService.Value;
        public IWarriorService WarriorService => _lazyWarriorService.Value;

    }

    /*public class ServiceManager : IServiceManager
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IQuestService _questService;
        private readonly IWarriorService _warriorService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            // Инициализация сервисов напрямую
            _enrollmentService = new EnrollmentService(repositoryManager);
            _questService = new QuestService(repositoryManager);
            _warriorService = new WarriorService(repositoryManager);
        }

        public IEnrollmentService EnrollmentService => _enrollmentService;
        public IQuestService QuestService => _questService;
        public IWarriorService WarriorService => _warriorService;
    }*/
}
