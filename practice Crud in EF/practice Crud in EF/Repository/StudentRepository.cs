using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_Crud_in_EF.Data;
using practice_Crud_in_EF.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace practice_Crud_in_EF.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<List<StudentModel>> GetStudentDetail()
        {
            var result = await _context.Students.Select(x => new StudentModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                EnRoll = x.EnRoll
            }).ToListAsync();

            return result;
        }

        public async Task<StudentModel> GetStudentByIdAsync(int studId)
        {
            var result = await _context.Students.Where(x => x.Id == studId).Select(x => new StudentModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                EnRoll = x.EnRoll

            }).FirstOrDefaultAsync();
            return result;

        }

        public async Task<int> AddStudentAsync(StudentModel studentModel)
        {
            var stud = new StudentModel()
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Address = studentModel.Address,
                EnRoll = studentModel.EnRoll
            };
            _context.Students.Add(stud);
            await _context.SaveChangesAsync();
            return stud.Id;
        }

        public async Task UpadteStudentAsync(StudentModel studentModel, int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                stud.FirstName = studentModel.FirstName;
                stud.LastName = studentModel.LastName;
                stud.Address = studentModel.Address;
                stud.EnRoll = studentModel.EnRoll;

                await _context.SaveChangesAsync();
            }
        }
    }
}
