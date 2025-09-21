using CQRS_Ex_1.Data;
using CQRS_Ex_1.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Ex_1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<List<StudentModel>> GetAllStudentAsync()
        {
            var result = await _studentContext.studentModels.ToListAsync();
            return result;
        }

        public async Task<StudentModel> GetBYIdStudentAsync(int id)
        {
            var result = await _studentContext.studentModels.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<StudentModel> AddStudentAsync(StudentModel student)
        {
            var result = _studentContext.studentModels.Add(student);
            await _studentContext.SaveChangesAsync();
            return student;
        }

        public async Task<int> UpdateStudentAsync(StudentModel student)
        {
            _studentContext.studentModels.Update(student);
            return await _studentContext.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var result = _studentContext.studentModels.Where(x => x.Id==id).FirstOrDefault();
            _studentContext.studentModels.Remove(result);
            return await _studentContext.SaveChangesAsync();
        }

    }
}
