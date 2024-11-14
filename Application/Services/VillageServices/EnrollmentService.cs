using Application.DTOs;
using Application.Interfaces;
using Entities.Interfaces;
using Entities.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal sealed class EnrollmentService : IEnrollmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        public EnrollmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            var enrollments = await _repositoryManager.enrollmentRepository.GetAllAsync();
            return enrollments ?? Enumerable.Empty<Enrollment>();
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            var enrollment = await _repositoryManager.enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null)
                throw new KeyNotFoundException($"Enrollment with ID {id} was not fount ");
            return enrollment;
        }

        public async Task<EnrollmentDTO> CreateAsync(EnrollmentDTO enrollmentDto)
        {
            var enrollment = enrollmentDto.Adapt<Enrollment>();
            var warriorId = await _repositoryManager.warriorRepository.GetByIdAsync(enrollmentDto.WarriorId);
            var questId = await _repositoryManager.questRepository.GetByIdAsync(enrollmentDto.QuestId);
            if(warriorId == null) throw new ArgumentException($"Warrior with ID {enrollmentDto.WarriorId} does not exist");
            if (questId == null) throw new ArgumentException($"Quest with ID {enrollmentDto.WarriorId} does not exist");

            await _repositoryManager.enrollmentRepository.Insert(enrollment);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
            return enrollment.Adapt(enrollmentDto);
        }

        public async Task UpdateAsync(int id, EnrollmentDTO enrollmentDto)
        {
            var enrollment = await _repositoryManager.enrollmentRepository.GetByIdAsync(id);
            if (enrollment is null) throw new KeyNotFoundException($"Enrollment with ID {id} was not fount");
            var warriorId = await _repositoryManager.warriorRepository.GetByIdAsync(enrollmentDto.WarriorId);
            var questId = await _repositoryManager.questRepository.GetByIdAsync(enrollmentDto.QuestId);
            if (warriorId == null) throw new ArgumentException($"Warrior with ID {enrollmentDto.WarriorId} does not exist");
            if (questId == null) throw new ArgumentException($"Quest with ID {enrollmentDto.WarriorId} does not exist");

            enrollment.WarriorId = enrollmentDto.WarriorId;
            enrollment.QuestId = enrollmentDto.QuestId;
            enrollment.Level = enrollment.Level;
            await _repositoryManager.unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var enrollment = await _repositoryManager.enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) throw new KeyNotFoundException($"Enrollment with ID {id} was not fount");
            await _repositoryManager.enrollmentRepository.Remove(enrollment);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
        }
    }
}
