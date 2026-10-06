using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyDashboardBackend.Data;
using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;
using StudyDashboardBackend.Services;
namespace StudyDashboardBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        
        [HttpGet("test-endpoint")]
        [Authorize]
        public IActionResult testEndpoint()
        {
            return Ok("test passed");
        }

        [HttpPost()]
        [Authorize]
        public async Task<ActionResult<Course>> CreateCourse(CreateCourseDto courseRequest)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            var newCourse = courseService.createCourse(courseRequest,userId);
            return Ok(newCourse);
        }
    }
}
