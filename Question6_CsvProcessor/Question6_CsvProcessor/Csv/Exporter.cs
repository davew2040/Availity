using Question6_CsvProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Question6_CsvProcessor.Csv
{
    public static class Exporter
    {
        public static async Task ExportToFileAsync(List<Enrollee> enrollees, string outputPath)
        {
            using (StreamWriter fs = new StreamWriter(outputPath))
            {
                WriteColumnHeader(fs);

                foreach (var enrollee in enrollees)
                {
                    List<string> rowValues = new List<string>();

                    foreach (var columnName in Columns.DefaultColumnOrder)
                    {
                        if (columnName == Columns.UserId)
                        {
                            rowValues.Add(enrollee.UserId);
                        }
                        else if (columnName == Columns.Version)
                        {
                            rowValues.Add(enrollee.Version.ToString());
                        }
                        else if (columnName == Columns.FirstName)
                        {
                            rowValues.Add(enrollee.FirstName);
                        }
                        else if (columnName == Columns.LastName)
                        {
                            rowValues.Add(enrollee.LastName);
                        }
                        else if (columnName == Columns.InsuranceCompany)
                        {
                            rowValues.Add(enrollee.InsuranceCompany);
                        }
                    }

                    await fs.WriteLineAsync(string.Join(',', rowValues));
                }
            }
        }

        private static void WriteColumnHeader(StreamWriter writer)
        {
            writer.WriteLine(string.Join(',', Columns.DefaultColumnOrder));
        }
    }
}
