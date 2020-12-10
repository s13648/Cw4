using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Cw4.Models;

namespace Cw4.Dal
{
    public class EnrollmentDbService : IEnrollmentDbService
    {
        private readonly IConfig _config;

        public EnrollmentDbService(IConfig config)
        {
            _config = config;
        }

        private const string GetEnrollmentForStudentSql = @"SELECT 
	                ST.Name AS StudyName,
	                E.Semester
                FROM 
	                [Student] AS S JOIN 
	                [Enrollment] AS E ON S.IdEnrollment = E.IdEnrollment JOIN
	                [Studies] AS ST ON E.IdStudy = ST.IdStudy
                WHERE
	                S.IndexNumber = @IndexNumber";

        public async Task<IEnumerable<StudentEnrollment>> GetStudentEnrollments(string studentIndex)
        {
            await using var sqlConnection = new SqlConnection(_config.ConnectionString);

            await using var command = new SqlCommand(GetEnrollmentForStudentSql, sqlConnection) { CommandType = CommandType.Text };
            command.Parameters.AddWithValue("IndexNumber", studentIndex);
            await sqlConnection.OpenAsync();

            var sqlDataReader = await command.ExecuteReaderAsync();
            var students = new List<StudentEnrollment>();
            while (await sqlDataReader.ReadAsync())
            {
                var student = new StudentEnrollment
                {
                    Semester = int.Parse(sqlDataReader[nameof(Student.Semester)].ToString()),
                    StudyName = sqlDataReader[nameof(Student.StudyName)].ToString()
                };
                students.Add(student);
            }

            return students;
        }
    }
}
