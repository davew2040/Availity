using System;
using System.Collections.Generic;
using System.Text;

namespace Question6_CsvProcessor.Csv
{
    public static class Columns
    {
        public static List<string> DefaultColumnOrder = new List<string> 
        { 
            Columns.UserId, 
            Columns.LastName, 
            Columns.FirstName, 
            Columns.InsuranceCompany, 
            Columns.Version 
        };

        public const string UserId = nameof(UserId);
        public const string FirstName = nameof(FirstName);
        public const string LastName = nameof(LastName);
        public const string Version = nameof(Version);
        public const string InsuranceCompany = nameof(InsuranceCompany);
    }
}
