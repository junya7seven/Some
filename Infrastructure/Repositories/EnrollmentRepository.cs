using Entities.Interfaces;
using Entities.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly VillageContext _context;

        public EnrollmentRepository(VillageContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync() => await _context.Enrollments.ToListAsync();
        public async Task<Enrollment> GetByIdAsync(int id) => await _context.Enrollments.FindAsync(id);
        public async Task Insert(Enrollment enrollment) => await _context.Enrollments.AddAsync(enrollment);
        public async Task Remove(Enrollment enrollment) => _context.Remove(enrollment);
        public async Task Update(Enrollment enrollment) => _context.Enrollments.Update(enrollment);

    }
}
