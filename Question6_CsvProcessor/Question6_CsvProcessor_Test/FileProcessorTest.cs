using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question6_CsvProcessor.Models;
using Question6_CsvProcessor.Processing;
using System.Collections.Generic;
using System.Linq;

namespace Question6_CsvProcessor_Test
{
    [TestClass]
    public class FileProcessorTest
    {
        [TestMethod]
        public void TestUserIdVersioning()
        {
            List<Enrollee> enrollees = new List<Enrollee>()
            {
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob2",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceOne",
                    Version = 2
                },
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob1",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceOne",
                    Version = 1
                },
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob3",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceOne",
                    Version = 3
                },
            };

            var groupedAndSorted = EnrolleeProcessor.GroupAndSortByInsuranceCompany(enrollees);

            Assert.AreEqual(groupedAndSorted["InsuranceOne"].Count, 1);
            Assert.AreEqual(groupedAndSorted["InsuranceOne"].First().FirstName, "Bob3");
        }

        [TestMethod]
        public void TestInsuranceCompanyGrouping()
        {
            List<Enrollee> enrollees = new List<Enrollee>()
            {
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceOne",
                    Version = 1
                },
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceTwo",
                    Version = 1
                },
                new Enrollee()
                {
                    UserId = "user1",
                    FirstName = "Bob",
                    LastName = "Smith",
                    InsuranceCompany = "InsuranceThree",
                    Version = 1
                },
            };

            var groupedAndSorted = EnrolleeProcessor.GroupAndSortByInsuranceCompany(enrollees);

            Assert.AreEqual(groupedAndSorted["InsuranceOne"].Count, 1);
            Assert.AreEqual(groupedAndSorted["InsuranceTwo"].Count, 1);
            Assert.AreEqual(groupedAndSorted["InsuranceThree"].Count, 1);
        }
    }
}
