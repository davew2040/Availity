using Question6_CsvProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6_CsvProcessor.Csv
{
    public static class Parser
    {
        public static async Task<IEnumerable<Enrollee>> ReadFromFileAsync(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not locate file with path [{path}].");
            }

            var lines = await File.ReadAllLinesAsync(path);

            var order = GetColumnOrder(lines[0]);
            var enrollees = new List<Enrollee>();

            for (int i=1; i<lines.Length; i++)
            {
                enrollees.Add(ParseLine(lines[i], order));
            }

            return enrollees;
        }

        private static List<string> GetColumnOrder(string orderLine)
        {
            return orderLine.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        }

        private static Enrollee ParseLine(string line, List<string> columnOrder)
        {
            var newEnrollee = new Enrollee();
            var split = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var column in Columns.DefaultColumnOrder)
            {
                if (!split.Any())
                {
                    throw new Exception($"Found invalid number of column values at row value [{line}].");
                }

                if (column == Columns.UserId)
                {
                    newEnrollee.UserId = split[0];
                }
                else if (column == Columns.FirstName)
                {
                    newEnrollee.FirstName = split[0];
                }
                else if (column == Columns.LastName)
                {
                    newEnrollee.LastName = split[0];
                }
                if (column == Columns.InsuranceCompany)
                {
                    newEnrollee.InsuranceCompany = split[0];
                }
                if (column == Columns.Version)
                {
                    newEnrollee.Version = int.Parse(split[0]);
                }

                split.RemoveAt(0);
            }

            return newEnrollee;
        }
    }
}
