using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Debolibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "tim", LastName = "corey" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains(newPerson, people);
        }

        [Theory]
        [InlineData("tim", "", "LastName")]
        [InlineData("", "corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        //[Fact]
        //public void ConvertModelsToCSV_ShouldWork()
        //{
        //    List<PersonModel> people = new List<PersonModel>
        //    {
        //        new PersonModel { FirstName = "tim", LastName = "corey" },
        //        new PersonModel { FirstName = "tm", LastName = "crey" },
        //        new PersonModel { FirstName = "t", LastName = "coy" }
        //    };
        //    List<string> expOutput = new List<string>
        //    {
        //        "tim,corey",
        //        "tm,crey",
        //        "t,coy"
        //    };
        //    List<string> actOutput = DataAccess.ConvertModelsToCSV(people);
        //    Assert.True(expOutput.SequenceEqual(actOutput));
        //}

        [Theory]
        [MemberData(nameof(GetPeople), MemberType =typeof(DataAccessTests))]
        public void ConvertModelsToCSV_ShouldWork(List<PersonModel> persons)
        {
            List<PersonModel> people = persons.ToList();
            List<string> expOutput = new List<string>
            {
                "tim,corey",
                "tm,crey",
                "t,coy"
            };
            List<string> actOutput = DataAccess.ConvertModelsToCSV(people);
            Assert.True(expOutput.SequenceEqual(actOutput));
        }

        public static IEnumerable<object[]> GetPeople()
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel { FirstName = "tim", LastName = "corey" },
                new PersonModel { FirstName = "tm", LastName = "crey" },
                new PersonModel { FirstName = "t", LastName = "coy" }
            };
            yield return new object[]
            {
                people
            };
        }

    }
}
