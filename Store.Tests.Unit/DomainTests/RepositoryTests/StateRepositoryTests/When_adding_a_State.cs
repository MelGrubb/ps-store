﻿using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Builders;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.StateRepositoryTests
{
    [TestFixture]
    public class When_adding_a_State : Given_a_StateRepository
    {
        private State _model;
        private State _result;

        protected override void Given()
        {
            base.Given();

            _model = StateBuilder.Simple().Build();
        }

        protected override void When()
        {
            base.When();

            _result = SUT.AddAsync(AdminUserId, _model).Result;
        }

        [Test]
        public void Then_the_new_State_should_have_an_Id()
        {
            _result.Id.ShouldBeGreaterThan(0);
        }
    }
}
