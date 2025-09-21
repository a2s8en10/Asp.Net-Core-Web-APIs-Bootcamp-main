using Dapper;
using Dapper_in_ASP.NET_CORE.Model;
using System.Data;
namespace Dapper_in_ASP.NET_CORE.Repositories
{
    public interface IDepartmentRepositories
    {
        IEnumerable<Department> GetAllDepartmentsAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Department GetDepartmentByIdAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void DMLDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);

        //    void AddDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        //    void UpdateDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        //    void DeleteDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
