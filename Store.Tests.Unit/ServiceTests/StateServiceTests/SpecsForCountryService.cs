using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Store.Common.Contracts;
using Store.Domain.Models;
using Store.Domain.Repositories;
using Store.Services;
using Store.Tests.Unit.Framework;

namespace Store.Tests.Unit.ServiceTests.StateServiceTests
{
    [TestFixture]
    public abstract class SpecsForStateService : SpecsForService<StateService>
    {
        protected List<State> Countries;

        protected override void Given()
        {
            base.Given();

            Countries = new List<State>
            {
                new State { Id = 1, Name = "First", Description = "First State", Abbreviation = "1st" },
                new State { Id = 2, Name = "Second", Description = "Second State", Abbreviation = "2nd" },
            };

            GetMockFor<IStateRepository>()
                .Setup(x => x.AddAsync(It.IsAny<int>(), It.IsAny<State>()))
                .Returns((int userId, State model) => Task.FromResult(model))
                .Callback((int userId, State model) =>
                {
                    model.Id = GetRandom.Id();
                    Countries.Add(model);
                });

            GetMockFor<IStateRepository>()
                .Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Countries.SingleOrDefault(x => x.Id == id)))
                .Callback((int userId, int id) => { Countries.RemoveAll(x => x.Id == id); });

            GetMockFor<IStateRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int userId, int id) => Task.FromResult(Countries.SingleOrDefault(x => x.Id == id)));

            GetMockFor<IStateRepository>()
                .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<Expression<Func<State, bool>>>(), It.IsAny<PagingOptions>()))
                .Returns((int userId, Expression<Func<State, bool>> predicate, PagingOptions queryOptions) => Task.FromResult(Countries.AsQueryable().Where(predicate).ToList()));

            GetMockFor<IStateRepository>()
                .Setup(x => x.SingleOrDefaultAsync(It.IsAny<int>(), It.IsAny<Expression<Func<State, bool>>>()))
                .Returns((int userId, Expression<Func<State, bool>> predicate) => Task.FromResult(Countries.AsQueryable().SingleOrDefault(predicate)));
        }
    }
}
