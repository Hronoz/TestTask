using TestTask.Models;

namespace TestTask.Services
{
    public interface IRecordService
    {
        public Result CalculateResult(IEnumerable<Record> records);
    }
}