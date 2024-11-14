using Entities.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly VillageContext _context;
        private IWarriorRepository _warriorRepository;
        private IQuestRepository _questRepository;
        private IEnrollmentRepository _enrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryManager(VillageContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public IWarriorRepository warriorRepository => _warriorRepository ?? new WarriorRepository(_context);
        public IEnrollmentRepository enrollmentRepository => _enrollmentRepository ?? new EnrollmentRepository(_context);
        public IQuestRepository questRepository => _questRepository ?? new QuestRepository(_context);

        public IUnitOfWork unitOfWork => _unitOfWork;
    }
}
