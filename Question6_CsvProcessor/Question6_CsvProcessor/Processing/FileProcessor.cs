using Question6_CsvProcessor.Csv;
using Question6_CsvProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6_CsvProcessor.Processing
{
    public static class FileProcessor
    {
        public static async Task ProcessFile(string inputPath, string outputPath)
        {
            var enrollees = await Parser.ReadFromFileAsync(inputPath);

            var groupedAndSorted = EnrolleeProcessor.GroupAndSortByInsuranceCompany(enrollees);

            foreach (var kvp in groupedAndSorted)
            {
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                var perCompanyOutputPath = Path.Combine(outputPath, GetDirectoryFromCompany(kvp.Key) + ".csv");

                await Exporter.ExportToFileAsync(kvp.Value, perCompanyOutputPath);
            }
        }

        private static string GetDirectoryFromCompany(string companyName)
        {
            companyName = companyName.Replace(' ', '-');
            companyName = companyName.Replace('/', '-');
            companyName = companyName.Replace('\\', '-');

            return companyName.ToLower();
        }
    }
}
