using System.Collections.Generic;
using Cw4.Models;

namespace Cw4.Dal
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
