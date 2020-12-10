using System.Collections.Generic;
using Cw4.Models;

namespace Cw4.Dal
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        public MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent = 1,FirstName="Jan",LastName = "Kowalski"},
                new Student{IdStudent = 2,FirstName="Anna",LastName = "Malewski"},
                new Student{IdStudent = 3,FirstName="Andrzej",LastName = "Andrzejewicz"},
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
