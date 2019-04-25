﻿using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;
using Store.Tests.Unit.Framework.Builders;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.AddressRepositoryTests
{
    [TestFixture]
    public class When_adding_an_Address_range : Given_an_AddressRepository
    {
        private List<Address> _models;
        private int _originalCount;

        protected override void Given()
        {
            base.Given();

            _models = new List<Address>
            {
                AddressBuilder.Typical().Build(),
                AddressBuilder.JoeCustomerShipping().Build()
            };

            _originalCount = SUT.CountAsync().Result;
        }

        protected override void When()
        {
            base.When();

            SUT.AddRangeAsync(AdminUserId, _models).Wait();
        }

        [Test]
        public void Then_the_new_addresses_should_have_an_Id()
        {
            _models.ForEach(x => x.Id.ShouldBeGreaterThan(0));
        }

        [Test]
        public void Then_the_new_addresses_were_added_to_the_table()
        {
            SUT.CountAsync().Result.ShouldBe(_originalCount + _models.Count);
        }
    }
}
