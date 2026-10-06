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
        public async Task<ActionResult<Course>> CreateCourseAsync(CreateCourseDto courseRequest)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            var newCourse = await courseService.CreateCourseAsync(courseRequest,userId);
            return Ok(newCourse);
        }

    [HttpGet("my")]
    [Authorize]
    public async Task<ActionResult<List<ListCourseDto>>> ListUserCoursesAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);

            var list = await courseService.ListUsersCoursesAsync(userId);
            return Ok(list);
            
        }
    [HttpDelete("{courseId:Guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteCourseAsync(Guid courseId) //to-do maybe change to GUID
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            await courseService.DeleteCourseAsync(userId, courseId);
            return NoContent();
        }

    [HttpGet("{courseId:Guid}")]
    [Authorize]
    public async Task<ActionResult<DetailCourseDto>> GetDetailCourseAsync(Guid courseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            var courseDetails = await courseService.DetailCourseAsync(userId,courseId);
            if(courseDetails is null)
            {
                return NotFound();
            }
            return Ok(courseDetails);
        }

    [HttpPut("{courseId:Guid}")]
    public async Task<IActionResult> UpdateCourseAsync(UpdateCourseDto requestDto,Guid courseId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if(userIdClaim is null)
            {
                return Unauthorized("Unauthorized access");
            }
            var userId = Guid.Parse(userIdClaim.Value);
            await courseService.UpdateCourseAsync(requestDto,userId,courseId);    
            return Ok();
        }
    }
}
