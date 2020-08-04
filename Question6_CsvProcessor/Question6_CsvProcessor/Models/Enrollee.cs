using System;
using System.Collections.Generic;
using System.Text;

namespace Question6_CsvProcessor.Models
{
    public class Enrollee
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InsuranceCompany { get; set; }
        public int Version { get; set; }
    }
}
