using Application.DTOs;
using Application.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Entities.Models;

namespace Application.Services
{
    internal sealed class QuestService : IQuestService
    {
        private readonly IRepositoryManager _repositoryManager;
        public QuestService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Quest>> GetAllAsync()
        {
            var quests = await _repositoryManager.questRepository.GetAllAsync();
            return quests ?? Enumerable.Empty<Quest>();
        }

        public async Task<Quest> GetByIdAsync(int id)
        {

            var quest = await _repositoryManager.questRepository.GetByIdAsync(id);
            if (quest == null) throw new KeyNotFoundException($"Quest with ID {id} was not fount ");
            return quest;

        }

        public async Task<QuestDTO> CreateAsync(QuestDTO questDto)
        {

            var quest = questDto.Adapt<Quest>();
            var exists = await _repositoryManager.questRepository.GetByIdAsync(questDto.QuestId);
            if (exists != null) throw new ArgumentException($"Quest with ID {questDto.QuestId} already exist");
            await _repositoryManager.questRepository.Insert(quest);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
            return quest.Adapt(questDto);

        }

        public async Task UpdateAsync(int id, QuestDTO questDto)
        {

            var quest = await _repositoryManager.questRepository.GetByIdAsync(id);
            if (quest == null) throw new KeyNotFoundException($"Quest with ID {id} was not fount ");
            if (questDto.Description != quest.Description && questDto.Description != null)
                quest.Description = questDto.Description;
            if (questDto.Reward != quest.Reward && questDto.Reward > 0)
                quest.Reward = questDto.Reward;

            await _repositoryManager.questRepository.Update(quest);
            await _repositoryManager.unitOfWork.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var quest = await _repositoryManager.questRepository.GetByIdAsync(id);
            if (quest == null) throw new KeyNotFoundException($"Quest with ID {id} was not fount ");
            
            await _repositoryManager.questRepository.Remove(quest);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
            
        }
    }
}
