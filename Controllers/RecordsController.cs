using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private readonly ICSVService _csvService;
        private readonly TaskDbContext _dbContext;
        private readonly IRecordService _recordService;

        public RecordsController(ICSVService csvService, TaskDbContext dbContext, IRecordService recordService)
        {
            _csvService = csvService;
            _dbContext = dbContext;
            _recordService = recordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFileCollection file, CancellationToken cancellationToken = default)
        {
            Stream readStream = file[0].OpenReadStream();
            List<Record> records = _csvService.ReadCSV<Record, RecordMap>(readStream, maxRecords: 10000).ToList();
            if (records.Count == 0)
            {
                return NoContent();
            }

            Result result = _recordService.CalculateResult(records);
            result.RowQty = records.Count;
            result.FileName = file[0].FileName;

            records.ForEach(m => m.FileName = file[0].FileName);

            if (_dbContext.Records.Any(value => value.FileName == file[0].FileName))
            {
                IQueryable<Record> toUpdate = _dbContext.Records.Where(p => p.FileName == file[0].FileName);
                _dbContext.Records.RemoveRange(toUpdate);
                _dbContext.Results.Remove(_dbContext.Results.FirstOrDefault(x => x.FileName == file[0].FileName));
            }
            await _dbContext.Results.AddAsync(result, cancellationToken);
            await _dbContext.Records.AddRangeAsync(records, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetByFileName(string fileName, CancellationToken cancellationToken = default)
        {
            List<Record>? result = await _dbContext.Records.Where(x => x.FileName == fileName)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result is null
                ? NotFound()
                : Ok(result);
        }
    }
}