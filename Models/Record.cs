using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    [Table("Records")]
    public class Record : IModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; } = null!;
        /// <summary>
        /// Date and time if format YYYY-MM-DD_hh-mm-ss
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Time in seconds
        /// </summary>
        public int Time { get; set; }
        public double Value { get; set; }

        public bool Validate()
        {
            if (Date >= new DateTime(2000, 01, 01) && DateTime.Now <= Date)
                return false;
            if (Time < 0)
                return false;
            if (Value < 0)
                return false;
            return true;
        }
    }

    public sealed class RecordMap : CsvHelper.Configuration.ClassMap<Record>
    {
        public RecordMap()
        {
            string format = "yyyy-MM-dd_HH-mm-ss";
            Map(m => m.Date)
                .TypeConverterOption.Format(format)
                .Index(0);
            Map(m => m.Time).Index(1);
            Map(m => m.Value).Index(2);
        }
    }
}