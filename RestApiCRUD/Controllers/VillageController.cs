using Application.DTOs;
using Application.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class VillageController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public VillageController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        /// <summary>
        /// Получение записи по id
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

            var enrollment = await _serviceManager.EnrollmentService.GetByIdAsync(id);
            return Ok(enrollment);
        }
        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Не найден</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _serviceManager.EnrollmentService.GetAllAsync();
            return Ok(enrollments);
        }
        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="enrollmentDto">Модель</param>
        /// <returns></returns>
        /// <response code="201">Модель создана</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="409">Модель уже существует</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnrollmentDTO enrollmentDto) // Using DTO to hide a property Enrollment
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _serviceManager.EnrollmentService.CreateAsync(enrollmentDto);
            return Ok();
        }
        /// <summary>
        /// Обновление записи
        /// </summary>
        /// <param name="enrollmentDto">Модель</param>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Данные не заполнены</response>
        /// <response code="401">Не авторизован</response>
        /// <response code="404">Модель не найдена</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, EnrollmentDTO enrollmentDto)
        {
            if (id <= 0) return BadRequest("Invalid ID.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _serviceManager.EnrollmentService.UpdateAsync(id, enrollmentDto);
            return Ok();
        }
        /// <summary>
        /// Удаление записи
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
            await _serviceManager.EnrollmentService.DeleteAsync(id);
            return Ok();
        }
    }
}
