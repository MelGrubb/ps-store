using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CountryRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Country_range : Given_a_CountryRepository
    {
        private List<Country> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<Country>
            {
                new Country
                {
                    Abbreviation = "YY",
                    Name = "New Country",
                    Description = "Unexpected, but welcome"
                },
                new Country
                {
                    Abbreviation = "ZZ",
                    Name = "Newer Country",
                    Description = "Also unexpected, but welcome"
                }
            };
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_address_should_have_an_Id()
        {
            SUT.CountAsync().Result.ShouldBe(4);
        }
    }
}
