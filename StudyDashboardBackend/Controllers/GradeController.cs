using StudyDashboardBackend.Services;
using StudyDashboardBackend.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using StudyDashboardBackend.Dtos;

namespace StudyDashboardBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GradeController(IGradeService gradeService) : ControllerBase
    {
        [HttpPost()]
        [Authorize]
        public async Task<ActionResult<Grade>> CreateGradeAsync(WriteGradeDto gradeRequest)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            var result = await gradeService.CreateGradeAsync(userId,gradeRequest);
            return result;
        }
    }
}
