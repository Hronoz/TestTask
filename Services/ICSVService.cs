using CsvHelper.Configuration;
using TestTask.Models;

namespace TestTask.Services
{
    public interface ICSVService
    {
        /// <summary>
        /// Reads a CSV file, according to <see cref="{TModel}"/> and <see cref="{TMap}"/>
        /// with a maximum number of rows
        /// </summary>
        /// <typeparam name="TModel">Model representing a row in database</typeparam>
        /// <typeparam name="TMap">Mapping function for Model</typeparam>
        public IEnumerable<TModel> ReadCSV<TModel, TMap>(Stream file, int maxRecords)
            where TModel : IModel
            where TMap : ClassMap;
    }
}