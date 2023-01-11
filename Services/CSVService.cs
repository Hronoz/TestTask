using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TestTask.Models;

namespace TestTask.Services
{
    public class CSVService : ICSVService
    {
        public IEnumerable<TModel> ReadCSV<TModel, TMap>(Stream file, int maxRecords)
            where TModel : IModel
            where TMap : ClassMap
        {
            List<TModel> results = new();
            CsvConfiguration config = new(new CultureInfo("ru-Ru"))
            {
                NewLine = Environment.NewLine,
                Delimiter = ";",
                HasHeaderRecord = false,
            };
            StreamReader reader = new(file);
            CsvReader csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<TMap>();
            for (int i = 0; i < maxRecords && csv.Read(); i++)
            {
                TModel? record = csv.GetRecord<TModel>();
                if (record is not null && record.Validate())
                    results.Add(record);
            }
            return results;
        }


    }
}