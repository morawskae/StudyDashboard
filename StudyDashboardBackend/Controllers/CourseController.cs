using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyDashboardBackend.Data;
using StudyDashboardBackend.Dtos;
using StudyDashboardBackend.Models;

namespace StudyDashboardBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(StudyDashboardDbContext context, IConfiguration configuration) : ControllerBase
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
            var newCourse = new Course{
                Code = courseRequest.Code,
                Name = courseRequest.Name,
                Description = courseRequest.Description,
                Credits = courseRequest.Credits,
                Semester = courseRequest.Semester,
                IsActive=true,
                UserId = userId
            };
            return Ok(newCourse);
        }
    }
}
