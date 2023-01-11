using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    [Table("Results")]
    public class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; } = null!;
        /// <summary>
        /// Maximum value of time minus minimum value of time
        /// </summary>
        public int AllTime { get; set; }
        /// <summary>
        /// Date and time of first operation (minimal date and time)
        /// </summary>
        public DateTime FirstOperationDate { get; set; }

        public double AverageTime { get; set; }

        public double AverageValue { get; set; }

        public double MedianValue { get; set; }

        /// <summary>
        /// Maximum value
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Minimal value
        /// </summary>
        public double MinValue { get; set; }
        /// <summary>
        /// Quantity of rows
        /// </summary>
        public int RowQty { get; set; }
    }
}