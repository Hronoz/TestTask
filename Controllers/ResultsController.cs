using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Models;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsController : Controller
    {
        private readonly TaskDbContext _dbContext;

        public ResultsController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByFilter([FromQuery] Filter filter, CancellationToken cancellationToken = default)
        {
            IQueryable<Result> query = _dbContext.Results;

            if (filter.FileName is not null)
            {
                query = query.Where(x => x.FileName == filter.FileName);
            }

            if (filter.DateRange is not null)
            {
                query = query.Where(x => x.FirstOperationDate >= filter.DateRange.From && x.FirstOperationDate <= filter.DateRange.To);
            }

            if (filter.ValueRange is not null)
            {
                query = query.Where(x => x.AverageValue >= filter.ValueRange.From && x.AverageValue <= filter.ValueRange.To);
            }

            if (filter.TimeRange is not null)
            {
                query = query.Where(x => x.AverageTime >= filter.TimeRange.From && x.AverageTime <= filter.TimeRange.To);
            }

            List<Result> result = await query.ToListAsync(cancellationToken);

            return Ok(result);
        }
    }
}
