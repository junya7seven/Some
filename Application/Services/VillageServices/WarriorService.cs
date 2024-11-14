using Application.DTOs;
using Application.Interfaces;
using Entities.Interfaces;
using Entities.Models;
using Mapster;

namespace Application.Services
{
    internal sealed class WarriorService : IWarriorService
    {
        private readonly IRepositoryManager _repositoryManager;
        public WarriorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Warrior>> GetAllAsync()
        {

            var warriors = await _repositoryManager.warriorRepository.GetAllAsync();
            return warriors ?? Enumerable.Empty<Warrior>();

        }

        public async Task<Warrior> GetByIdAsync(int id)
        {

            var warrior = await _repositoryManager.warriorRepository.GetByIdAsync(id);
            if (warrior == null) throw new KeyNotFoundException($"Warropr with ID {id} was not fount ");

            return warrior;

        }

        public async Task<WarriorDTO> CreateAsync(WarriorDTO warriorDto)
        {

            var warrior = warriorDto.Adapt<Warrior>();
            await _repositoryManager.warriorRepository.Insert(warrior);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
            return warrior.Adapt(warriorDto);
        }

        public async Task UpdateAsync(int id, WarriorDTO warriorDto)
        {
            try

            {
                var warrior = await _repositoryManager.warriorRepository.GetByIdAsync(id);
                if (warrior == null) throw new KeyNotFoundException($"Warropr with ID {id} was not fount ");

                if (warriorDto.FirstName != warrior.FirstName && warriorDto.FirstName != null)
                    warrior.FirstName = warriorDto.FirstName;
                if (warriorDto.NickName != warrior.NickName && warriorDto.NickName != null)
                    warrior.NickName = warriorDto.NickName;

                await _repositoryManager.warriorRepository.Update(warrior);
                await _repositoryManager.unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task DeleteAsync(int id)
        {
            var warrior = await _repositoryManager.warriorRepository.GetByIdAsync(id);
            if (warrior == null) throw new KeyNotFoundException($"Warropr with ID {id} was not fount ");

            await _repositoryManager.warriorRepository.Remove(warrior);
            await _repositoryManager.unitOfWork.SaveChangesAsync();
            
        }
    }
}
