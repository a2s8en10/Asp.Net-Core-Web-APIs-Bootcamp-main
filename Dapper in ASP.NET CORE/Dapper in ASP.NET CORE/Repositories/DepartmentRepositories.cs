using Dapper;
using Dapper_in_ASP.NET_CORE.Model;
using System.Data;

namespace Dapper_in_ASP.NET_CORE.Repositories
{
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private readonly IDbConnection _connection;

        public DepartmentRepositories(IDbConnection connection)
        {
            _connection = connection;
        }



        public IEnumerable<Department> GetAllDepartmentsAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<Department>(procedureName, parameters, commandType: commandType);
        }

        public Department GetDepartmentByIdAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.QueryFirstOrDefault<Department>(procedureName, parameters, commandType: commandType);
        }

        public void DMLDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Execute(procedureName, parameters, commandType: commandType);
        }

        //public void UpdateDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    _connection.Execute(procedureName, parameters, commandType: commandType);
        //}
        //public void AddDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    _connection.Execute(procedureName, parameters, commandType: commandType);
        //}
        //public void DeleteDepartmentAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    _connection.Execute(procedureName, parameters, commandType: commandType);
        //}
    }
}
