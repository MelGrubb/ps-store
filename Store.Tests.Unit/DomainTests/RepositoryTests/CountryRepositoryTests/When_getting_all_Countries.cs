using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CountryRepositoryTests
{
    [TestFixture]
    public class When_getting_all_Countries : Given_a_CountryRepository
    {
        private List<Country> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_Countries_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
