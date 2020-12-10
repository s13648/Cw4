using System.Collections.Generic;
using System.Threading.Tasks;
using Cw4.Models;

namespace Cw4.Dal
{
    public interface IEnrollmentDbService
    {
        public Task<IEnumerable<StudentEnrollment>> GetStudentEnrollments(string studentIndex);
    }
}
