using api.Dtos;
using api.Interfaces;
using api.Models;
using JobPortal.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfertController : ControllerBase
    {
        private readonly IJobOfertRepository jobOfertRepository;
        private readonly IRequirementRepository requirementRepository;
        private readonly IBenefitRepository benefitRepository;
        private readonly IDutyRepository dutyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICompanyRepository companyRepository;

        public JobOfertController(IJobOfertRepository jobOfertRepository,
                                  IRequirementRepository requirementRepository, 
                                  IBenefitRepository benefitRepository, 
                                  IDutyRepository dutyRepository,
                                  ICategoryRepository categoryRepository,
                                  ICompanyRepository companyRepository)
        {
            this.jobOfertRepository = jobOfertRepository;
            this.requirementRepository = requirementRepository;
            this.benefitRepository = benefitRepository;
            this.dutyRepository = dutyRepository;
            this.categoryRepository = categoryRepository;
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        public IActionResult InsertJobOfer(JobOfertDto dto)
        {
            var jobOfert = new JobOfert()
            {
                RecruitmentEndDate = dto.RecruitmentEndDate,
                PositionName = dto.PositionName,
                PositionLevel = dto.PositionLevel,
                EmploymentContract = dto.EmploymentContract,
                EmploymentType = dto.EmploymentType,
                JobType = dto.JobType,
                SalaryMinimum = dto.SalaryMinimum,
                SalaryMaximum = dto.SalaryMaximum,
                WorkDays = dto.WorkDays,
                WorkStartHour = dto.WorkStartHour,
                WorkEndHour = dto.WorkEndHour
            };

            return Ok(jobOfertRepository.Insert(jobOfert));
        }

        [HttpPost("company")]
        public IActionResult InsertCompany(CompanyDto dto)
        {
            var company = new Company()
            {
                CompanyName = dto.CompanyName,
                CompanyAddress = dto.CompanyAddress,
                CompanyDescription = dto.CompanyDescription,
                CompanyLocation = dto.CompanyLocation
            };

            return Ok(companyRepository.Insert(company));
        }

        [HttpPost("homePageJobOfert/{pageNumber}")]
        public IActionResult HomePageJobOfert(int pageNumber,FilterDto filter)
        {
            return Ok(jobOfertRepository.GetHomePageJobOferts(pageNumber - 1,filter));
        }

        [HttpGet("{jobOfertId}")]
        public IActionResult GetJobOfert(int jobOfertId)
        {
            return Ok(jobOfertRepository.GetJobOfert(jobOfertId));
        }

        [HttpGet("company")]
        public IActionResult GetAllCompanies()
        {
            return Ok(companyRepository.GetAll());
        }

        [HttpGet("company-{companyId}")]
        public IActionResult GetAllCompanies(int companyId)
        {
            return Ok(companyRepository.GetById(companyId));
        }

        [HttpGet("company/{jobOfertId}")]
        public IActionResult GetCompanyForJobOfertId(int jobOfertId)
        {
            return Ok(companyRepository.GetCompanyForJobOfert(jobOfertId));
        }

        [HttpPost("company/{companyId}-{jobOfertId}")]
        public IActionResult AddCompanyJobOfertRelation(int companyId, int jobOfertId)
        {
            return Ok(companyRepository.AddRelation(companyId,jobOfertId));
        }

        [HttpDelete("company/{companyId}")]
        public IActionResult DeleteCompany(int companyId)
        {
            try
            {
                companyRepository.DeleteCompany(companyId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("company/{companyId}")]
        public IActionResult UpdateCompany(int companyId,CompanyDto dto)
        {
            var company = new Company()
            {
                CompanyId = companyId,
                CompanyName = dto.CompanyName,
                CompanyAddress = dto.CompanyAddress,
                CompanyDescription = dto.CompanyDescription,
                CompanyLocation = dto.CompanyLocation
            };

            return Ok(companyRepository.Update(company));
        }

        [HttpPost("requirement")]
        public IActionResult InsertRequirement(RequirementDto requirementDto)
        {
            try
            {
                foreach (var item in requirementDto.Requirements)
                {
                    var requirement = new Requirement()
                    {
                        RequirementName = item
                    };
                    requirementRepository.Insert(requirementDto.JobOfertId,requirement);
                }
                return Ok("success");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("benefit")]
        public IActionResult InsertBenefit(BenefitDto benefitDto)
        {
            try
            {
                foreach (var item in benefitDto.Benefits)
                {
                    var benefit = new Benefit()
                    {
                        BenefitName = item
                    };
                    benefitRepository.Insert(benefitDto.JobOfertId, benefit);
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("duty")]
        public IActionResult InsertDuty(DutyDto dutyDto)
        {
            try
            {
                foreach (var item in dutyDto.Duties)
                {
                    var duty = new Duty()
                    {
                        DutyName = item
                    };
                    dutyRepository.Insert(dutyDto.JobOfertId, duty);
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("category")]
        public IActionResult InsertCategory(CategoryDto categoryDto)
        {
            try
            {
                foreach (var item in categoryDto.Categories)
                {
                    var category = new Category()
                    {
                        CategoryName = item
                    };
                    categoryRepository.Insert(categoryDto.JobOfertId, category);
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("category")]
        public IActionResult GetAllCategories()
        {
            return Ok(categoryRepository.GetAll());
        }

        [HttpGet("category/{jobOfertId}")]
        public IActionResult GetCategoriesForJobOfertId(int jobOfertId)
        {
            return Ok(categoryRepository.GetCategoryByJobId(jobOfertId));
        }

        [HttpGet]
        public IActionResult GetAllJobOferts(int jobOfertId)
        {
            return Ok(jobOfertRepository.GetAll());
        }

        [HttpGet("duty/{jobOfertId}")]
        public IActionResult GetAllDuties(int jobOfertId)
        {
            return Ok(dutyRepository.GetDuties(jobOfertId));
        }

        [HttpGet("benefit/{jobOfertId}")]
        public IActionResult GetAllBenefit(int jobOfertId)
        {
            return Ok(benefitRepository.GetBenefits(jobOfertId));
        }

        [HttpGet("requirement/{jobOfertId}")]
        public IActionResult GetAllRequirement(int jobOfertId)
        {
            return Ok(requirementRepository.GetRequirements(jobOfertId));
        }

        [HttpPost("jobOfert")]
        public IActionResult GetAllRequirement(FilterDto filterDto)
        {
            return Ok(jobOfertRepository.GetAllJobOfertsFilter(filterDto));
        }

        [HttpDelete("benefit/{jobOfertId}")]
        public IActionResult DeleteBenefits(int jobOfertId)
        {
            try
            {
                benefitRepository.DeleteBenefit(jobOfertId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("duty/{jobOfertId}")]
        public IActionResult DeleteDuties(int jobOfertId)
        {
            try
            {
                dutyRepository.DeleteDuty(jobOfertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("requirement/{jobOfertId}")]
        public IActionResult DeleteRequirements(int jobOfertId)
        {
            try
            {
                requirementRepository.DeleteRequirement(jobOfertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("category/{jobOfertId}")]
        public IActionResult DeleteCategories(int jobOfertId)
        {
            try
            {
                categoryRepository.DeleteCategory(jobOfertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{jobOfertId}")]
        public IActionResult DeleteJobOfert(int jobOfertId)
        {
            try
            {
                jobOfertRepository.DeleteJobOfert(jobOfertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{jobOfertId}")]
        public IActionResult UpdateJobOfert(int jobOfertId,JobOfertDto dto)
        {
            var jobOfert = new JobOfert()
            {
                Id = jobOfertId,
                RecruitmentEndDate = dto.RecruitmentEndDate,
                PositionName = dto.PositionName,
                PositionLevel = dto.PositionLevel,
                EmploymentContract = dto.EmploymentContract,
                EmploymentType = dto.EmploymentType,
                JobType = dto.JobType,
                SalaryMinimum = dto.SalaryMinimum,
                SalaryMaximum = dto.SalaryMaximum,
                WorkDays = dto.WorkDays,
                WorkStartHour = dto.WorkStartHour,
                WorkEndHour = dto.WorkEndHour

            };
            try
            {
                jobOfertRepository.UpdateJobOfert(jobOfertId, jobOfert);
                return Ok(jobOfertId);
            }catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
