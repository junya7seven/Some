using Application.DTOs;
using Application.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class QuestController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public QuestController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        /// <summary>
        /// Получение квеста по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Не найден</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quests = await _serviceManager.QuestService.GetByIdAsync(id);
            return Ok(quests);
        }
        /// <summary>
        /// Получение всех квестов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Не найден</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quests = await _serviceManager.QuestService.GetAllAsync();
            if (quests == null)
                return NotFound();
            return Ok(quests);
        }
        /// <summary>
        /// Создание квеста
        /// </summary>
        /// <param name="questDto">Модель</param>
        /// <returns></returns>
        /// <response code="201">Модель создана</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="409">Модель уже существует</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestDTO questDto) // Using DTO to hide a property Enrollment
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _serviceManager.QuestService.CreateAsync(questDto);
            return CreatedAtAction(nameof(GetById), new { id = exists.QuestId }, exists);
        }
        /// <summary>
        /// Обновление квеста
        /// </summary>
        /// <param name="questDto">Модель</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Модель не найдена</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPatch]
        public async Task<IActionResult> Update(QuestDTO questDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _serviceManager.QuestService.UpdateAsync(questDto.QuestId, questDto);
            return Ok();
        }
        /// <summary>
        /// Удаление квеста
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Модель не найдена</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.QuestService.DeleteAsync(id);
            return Ok();
        }
    }
}
