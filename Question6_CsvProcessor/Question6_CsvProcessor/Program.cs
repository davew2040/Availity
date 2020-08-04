using Question6_CsvProcessor.Csv;
using Question6_CsvProcessor.Processing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Question6_CsvProcessor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Must provide two arguments: (1) input CSV file, and (2) output directory of by-insurance-company results");
            }

            await FileProcessor.ProcessFile(args[0], args[1]);
        }
    }
}
