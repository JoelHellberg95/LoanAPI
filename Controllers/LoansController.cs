using LoanAPI.Enum;
using LoanAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private static List<LoanApplication> loanApplications = new List<LoanApplication>
    {
        new LoanApplication
        {
            Id = 1,
            Borrower = new User { Id = 22, FirstName = "Per", LastName = "Nilsson", Income = 36000 },
            Amount = 10000,
            Status = LoanStatus.Submitted,
            Date = DateTime.Now.AddDays(-2)
        },
        new LoanApplication
        {
            Id = 2,
            Borrower = new User { Id = 42, FirstName = "Linda", LastName = "Svensson", Income = 25000 },
            Amount = 10000,
            Status = LoanStatus.Submitted,
            Date = DateTime.Now.AddDays(-6)
        },
        new LoanApplication
        {
            Id = 3,
            Borrower = new User { Id = 4123, FirstName = "Sven", LastName = "Person", Income = 28000 },
            Amount = 10000,
            Status = LoanStatus.Submitted,
            Date = DateTime.Now.AddDays(-5)
        },
        new LoanApplication
        {
            Id = 4,
            Borrower = new User { Id = 1, FirstName = "Anders", LastName = "Andersson", Income = 39000 },
            Amount = 10000,
            Status = LoanStatus.Submitted,
            Date = DateTime.Now.AddDays(-3)
        },
        new LoanApplication
        {
            Id = 5,
            Borrower = new User { Id = 2, FirstName = "Jan", LastName = "Eklund", Income = 42000 },
            Amount = 20000,
            Status = LoanStatus.Approved,
            Date = DateTime.Now.AddDays(-3)
        },
         new LoanApplication
        {
            Id = 6,
            Borrower = new User { Id = 3, FirstName = "Erik", LastName = "Björkman", Income = 12000 },
            Amount = 20000,
            Status = LoanStatus.Rejected,
            Date = DateTime.Now.AddDays(-3)
        }
        };


        // GET: api/Loans
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(loanApplications);
        }

        // GET: api/Loans/status/{status}
        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(LoanStatus status)
        {
            var applications = loanApplications.Where(app => app.Status == status).ToList();

            if (!applications.Any())
            {
                return NotFound("Status not found in any existing case.");
            }


            return Ok(applications);
        }

        // GET: api/Loans/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var application = loanApplications.FirstOrDefault(app => app.Id == id);

            if (application == null)
                return NotFound();

            return Ok(application);
        }

        // GET: api/Loans/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var applications = loanApplications.Where(app => app.Borrower.Id == userId).ToList();
            return Ok(applications);
        }

        // POST: api/Loans
        [HttpPost]
        public IActionResult Post([FromBody] LoanApplication application)
        {
            application.Id = loanApplications.Count + 1;
            application.Date = DateTime.Now;
            loanApplications.Add(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        // PUT: api/Loans/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoanApplication updatedApplication)
        {
            var existingApplication = loanApplications.FirstOrDefault(app => app.Id == id);

            if (existingApplication == null)
                return NotFound();

            if (updatedApplication.Borrower.Id < 1)
            {
                return BadRequest("Borrower ID can't be less than 1.");
            }

            if (updatedApplication.Amount < 1)
            {
                return BadRequest("Amount can't be less than 1.");
            }

            existingApplication.Status = updatedApplication.Status;
            existingApplication.Amount = updatedApplication.Amount;
            existingApplication.Borrower = updatedApplication.Borrower;
            existingApplication.Date = updatedApplication.Date;

            return Ok(existingApplication);
        }

        // DELETE: api/Loans/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var application = loanApplications.FirstOrDefault(app => app.Id == id);

            if (application == null)
                return NotFound();

            loanApplications.Remove(application);
            return NoContent();
        }
    }
}
