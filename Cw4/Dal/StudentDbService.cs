using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Cw4.Models;

namespace Cw4.Dal
{
    public class StudentDbService : IStudentDbService
    {
        private string _getStudentsSql = @"SELECT 
	                                        S.FirstName,
	                                        S.LastName,
	                                        S.BirthDate,
	                                        ST.Name AS StudyName,
	                                        E.Semester
                                        FROM 
	                                        [Student] AS S JOIN 
	                                        [Enrollment] AS E ON S.IdEnrollment = E.IdEnrollment JOIN
	                                        [Studies] AS ST ON E.IdStudy = ST.IdStudy
                                        ";
        private readonly IConfig _config;

        public StudentDbService(IConfig config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            await using var sqlConnection = new SqlConnection(_config.ConnectionString);
            await using var command = new SqlCommand(_getStudentsSql,sqlConnection) {CommandType = CommandType.Text};
            await sqlConnection.OpenAsync();

            var sqlDataReader = await command.ExecuteReaderAsync();
            var students = new List<Student>();
            while (await sqlDataReader.ReadAsync())
            {
                var student = new Student
                {
                    BirthDate = DateTime.Parse(sqlDataReader[nameof(Student.BirthDate)]?.ToString()),
                    FirstName = sqlDataReader[nameof(Student.FirstName)].ToString(),
                    LastName = sqlDataReader[nameof(Student.LastName)].ToString(),
                    Semester = int.Parse(sqlDataReader[nameof(Student.Semester)].ToString()),
                    StudyName = sqlDataReader[nameof(Student.StudyName)].ToString()
                };
                students.Add(student);
            }

            return students;
        }
    }
}
