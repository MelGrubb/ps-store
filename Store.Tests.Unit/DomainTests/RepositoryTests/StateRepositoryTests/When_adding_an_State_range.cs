using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Mothers;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.StateRepositoryTests
{
    [TestFixture]
    public class When_adding_an_State_range : Given_a_StateRepository
    {
        private List<State> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            _models = new List<State>
            {
                StateMother.Simple(),
                StateMother.Simple()
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_States_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_States_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
