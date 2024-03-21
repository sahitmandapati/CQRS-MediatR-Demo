

using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Models;
using Microsoft.EntityFrameworkCore;


namespace CQRS_MediatR_Demo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _dbContext;

        public StudentRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _dbContext.StudentDetails.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.StudentDetails.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.StudentDetails.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.StudentDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContext.StudentDetails.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContext.StudentDetails.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

