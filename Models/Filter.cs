namespace TestTask.Models
{
    public class Filter
    {
        public string? FileName { get; set; }

        public Range<DateTime>? DateRange { get; set; }

        public Range<int>? TimeRange { get; set; }

        public Range<float>? ValueRange { get; set; }
    }
}