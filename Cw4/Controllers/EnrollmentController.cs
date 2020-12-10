using System.Threading.Tasks;
using Cw4.Dal;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/enrollment")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentDbService _enrollmentDbService;

        public EnrollmentController(IEnrollmentDbService enrollmentDbService)
        {
            _enrollmentDbService = enrollmentDbService;
        }

        [HttpGet("{studentIndex}")]
        public async Task<IActionResult> GetStudentEnrollments(string studentIndex)
        {
            return Ok(await _enrollmentDbService.GetStudentEnrollments(studentIndex));
        }
    }
}
