using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.StateRepositoryTests
{
    [TestFixture]
    public class When_adding_an_State_range : Given_a_StateRepository
    {
        private List<State> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<State>
            {
                new State
                {
                    Abbreviation = "YY",
                    Name = "New State",
                    Description = "Unexpected, but welcome"
                },
                new State
                {
                    Abbreviation = "ZZ",
                    Name = "Newer State",
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
            SUT.CountAsync().Result.ShouldBe(58);
        }
    }
}
