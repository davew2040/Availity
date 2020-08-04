using Question6_CsvProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question6_CsvProcessor.Processing
{
    public static class EnrolleeProcessor
    {
        public static Dictionary<string, List<Enrollee>> GroupAndSortByInsuranceCompany(IEnumerable<Enrollee> allEnrollees)
        {
            Dictionary<string, IEnumerable<Enrollee>> grouped = GroupByInsuranceCompany(allEnrollees);

            Dictionary<string, List<Enrollee>> sorted = grouped.ToDictionary(
                g => g.Key,
                g => g.Value.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList()
            );

            return sorted;
        }

        private static Dictionary<string, IEnumerable<Enrollee>> GroupByInsuranceCompany(IEnumerable<Enrollee> allEnrollees)
        {
            Dictionary<string, IEnumerable<Enrollee>> grouped = allEnrollees.GroupBy(e => e.InsuranceCompany).ToDictionary(g => g.Key, g => FilterUserIdsByVersion(g.ToList()));

            return grouped;
        }

        private static IEnumerable<Enrollee> FilterUserIdsByVersion(IEnumerable<Enrollee> enrollees)
        {
            var highestVersionEnrollees = enrollees.GroupBy(e => e.UserId)
                .Select(g => g.Where(e => e.Version == g.Max(e2 => e2.Version)));

            return highestVersionEnrollees.Select(e => e.First());
        }
    }
}
