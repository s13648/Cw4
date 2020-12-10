using System.Collections.Generic;
using System.Threading.Tasks;
using Cw4.Models;

namespace Cw4.Dal
{
    public interface IStudentDbService
    {
        public Task<IEnumerable<Student>> GetStudents();
    }
}
