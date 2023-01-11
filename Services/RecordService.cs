using TestTask.Models;

namespace TestTask.Services
{
    public class RecordService : IRecordService
    {
        public Result CalculateResult(IEnumerable<Record> records) =>
            new()
            {
                AllTime = records.Max(m => m.Time) - records.Min(m => m.Time),
                FirstOperationDate = records.Min(m => m.Date),
                AverageTime = records.Average(m => m.Time),
                AverageValue = records.Average(m => m.Value),
                MedianValue = CalculateMedian(records),
                MaxValue = records.Max(m => m.Value),
                MinValue = records.Min(m => m.Value)
            };

        public double CalculateMedian(IEnumerable<Record> records)
        {
            IOrderedEnumerable<double> sortedValues = records.Select(m => m.Value).OrderBy(m => m);
            double mid = sortedValues.ElementAt(sortedValues.Count() / 2);
            return sortedValues.Count() % 2 == 0
                ? mid
                : (mid + (mid - 1)) / 2;
        }
    }
}