using practice_Crud_in_EF.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace practice_Crud_in_EF.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> GetStudentDetail();
        Task<StudentModel> GetStudentByIdAsync(int studId);
        Task<int> AddStudentAsync(StudentModel studentModel);
        Task UpadteStudentAsync(StudentModel studentModel, int id);
    }
}
