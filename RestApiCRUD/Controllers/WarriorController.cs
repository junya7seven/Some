using Application.DTOs;
using Application.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class WarriorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public WarriorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        /// <summary>
        /// Получение воина по id
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
            if (id <= 0) return BadRequest("Invalid ID.");

            var warrior = await _serviceManager.WarriorService.GetByIdAsync(id);
            return Ok(warrior);
        }
        /// <summary>
        /// Получение всех воинов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Не найден</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warriors = await _serviceManager.WarriorService.GetAllAsync();
            if (warriors == null)
                return NotFound();
            return Ok(warriors);
        }
        /// <summary>
        /// Создание воина
        /// </summary>
        /// <param name="warriotDto">Модель</param>
        /// <returns></returns>
        /// <response code="201">Модель создана</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="409">Модель уже существует</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarriorDTO warriotDto) // Using DTO to hide a property Enrollment
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _serviceManager.WarriorService.CreateAsync(warriotDto);
            if (exists == null)
                return Conflict("The warrior already exists");

            return CreatedAtAction(nameof(GetById), new { id = exists.FirstName }, exists);
        }
        /// <summary>
        /// Обновление воина
        /// </summary>
        /// <param name="warriorDto">Модель</param>
        /// <returns>Обновление квеста</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Модель не найдена</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, WarriorDTO warriorDto)
        {
            if (id <= 0) return BadRequest("Invalid ID.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _serviceManager.WarriorService.UpdateAsync(id, warriorDto);
            return Ok();
        }
        /// <summary>
        /// Удаление воина
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
            if (id <= 0) return BadRequest("Invalid ID.");
            await _serviceManager.WarriorService.DeleteAsync(id);
            return Ok();
        }
    }
}
