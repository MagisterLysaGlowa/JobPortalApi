using api.Dtos;
using api.Interfaces;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEducationRepository educationRepository;
        private readonly IExperienceRepository experienceRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IAbilityRepository abilityRepository;
        private readonly ILanguageRepository languageRepository;
        private readonly ILinkRepository linkRepository;

        public UserController(ILogger<UserController> logger, 
                              IWebHostEnvironment webHostEnvironment, 
                              IEducationRepository educationRepository, 
                              IExperienceRepository experienceRepository,
                              ICourseRepository courseRepository,
                              IAbilityRepository abilityRepository,
                              ILanguageRepository languageRepository,
                              ILinkRepository linkRepository
            )
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.educationRepository = educationRepository;
            this.experienceRepository = experienceRepository;
            this.courseRepository = courseRepository;
            this.abilityRepository = abilityRepository;
            this.languageRepository = languageRepository;
            this.linkRepository = linkRepository;
        }
        [HttpGet("GetAvatar/{fileName}")]
        public async Task<IActionResult> GetAvatar(string fileName)
        {
            var uploadsFolder = Path.Combine(webHostEnvironment.ContentRootPath, "Uploads/Avatar");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (System.IO.File.Exists(filePath))
            {
                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                return File(imageBytes, "image/png"); // You can set the appropriate content type here based on your image type.
            }
            else
            {
                return NotFound("Image not found.");
            }
        }

        /*USER EDUCATION METHODS*/
        [HttpPost("education")]
        public IActionResult InsertEducation(EducationDto dto)
        {
            var education = new Education()
            {
                SchoolName = dto.SchoolName,
                Location = dto.Location,
                EducationLevel = dto.EducationLevel,
                Field = dto.Field,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            return Created("success", educationRepository.Insert(dto.UserId,education));
        }
        [HttpDelete("education/{educationId}")]
        public IActionResult RemoveEducation(int educationId)
        {
            return Ok(educationRepository.Remove(educationId));
        }

        [HttpPut("education/{educationId}")]
        public IActionResult UpdateEducation(int educationId,EducationDto dto)
        {
            var education = new Education()
            {
                SchoolName = dto.SchoolName,
                Location = dto.Location,
                EducationLevel = dto.EducationLevel,
                Field = dto.Field,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            return Ok(educationRepository.Update(educationId,education));
        }

        /*USER EXPERIENCE METHODS*/

        [HttpPost("experience")]
        public IActionResult InsertExperience(ExperienceDto dto)
        {
            var experience = new Experience()
            {
                CompanyName = dto.CompanyName,
                Location = dto.Location,
                Proffesion = dto.Proffesion,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            return Created("success", experienceRepository.Insert(dto.UserId, experience));
        }

        [HttpDelete("experience/{experienceId}")]
        public IActionResult RemoveExperience(int experienceId)
        {
            return Ok(experienceRepository.Remove(experienceId));
        }

        [HttpPut("experience/{experienceId}")]
        public IActionResult UpdateExperience(int experienceId, ExperienceDto dto)
        {
            var experience = new Experience()
            {
                CompanyName = dto.CompanyName,
                Location = dto.Location,
                Proffesion = dto.Proffesion,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            return Ok(experienceRepository.Update(experienceId, experience));
        }

        [HttpPost("course")]
        public IActionResult InsertCourse(CourseDto dto)
        {
            var course = new Course()
            {
                CourseName = dto.CourseName,
                CourseOrganizer = dto.CourseOrganizer,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            return Created("success", courseRepository.Insert(dto.UserId, course));
        }

        [HttpDelete("course/{courseId}")]
        public IActionResult RemoveCourse(int courseId)
        {
            return Ok(courseRepository.Remove(courseId));
        }

        [HttpPut("course/{courseId}")]
        public IActionResult UpdateCourse(int courseId, CourseDto dto)
        {
            var course = new Course()
            {
                CourseName = dto.CourseName,
                CourseOrganizer = dto.CourseOrganizer,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            return Ok(courseRepository.Update(courseId, course));
        }

        [HttpPost("ability")]
        public IActionResult InsertAbility(AbilityDto dto)
        {
            var ability = new Ability()
            {
                AbilityName = dto.AbilityName,
            };

            return Created("success", abilityRepository.Insert(dto.UserId, ability));
        }

        [HttpDelete("ability/{abilityId}")]
        public IActionResult RemoveAbility(int abilityId)
        {
            return Ok(abilityRepository.Remove(abilityId));
        }

        [HttpPut("ability/{abilityId}")]
        public IActionResult UpdateAbility(int abilityId, AbilityDto dto)
        {
            var ability = new Ability()
            {
                AbilityName= dto.AbilityName,
            };

            return Ok(abilityRepository.Update(abilityId, ability));
        }

        [HttpPost("language")]
        public IActionResult InsertLanguage(LanguageDto dto)
        {
            var language = new Language()
            {
                LanguageName = dto.LanguageName,
                LanguageLevel = dto.LanguageLevel,
            };

            return Created("success", languageRepository.Insert(dto.UserId, language));
        }

        [HttpDelete("language/{languageId}")]
        public IActionResult RemoveLanguage(int languageId)
        {
            return Ok(languageRepository.Remove(languageId));
        }

        [HttpPut("language/{languageId}")]
        public IActionResult UpdateLanguage(int languageId, LanguageDto dto)
        {
            var language = new Language()
            {
                LanguageName = dto.LanguageName,
                LanguageLevel = dto.LanguageLevel,
            };

            return Ok(languageRepository.Update(languageId, language));
        }

        [HttpPost("link")]
        public IActionResult InsertLink(LinkDto dto)
        {
            var link = new Link()
            {
                LinkContent = dto.LinkContent,
            };

            return Created("success", linkRepository.Insert(dto.UserId, link));
        }

        [HttpDelete("link/{linkId}")]
        public IActionResult RemoveLink(int linkId)
        {
            return Ok(linkRepository.Remove(linkId));
        }

        [HttpPut("link/{linkId}")]
        public IActionResult UpdateLink(int linkId, LinkDto dto)
        {
            var link = new Link()
            {
                LinkContent = dto.LinkContent,
            };

            return Ok(linkRepository.Update(linkId, link));
        }
    }
}
