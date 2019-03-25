using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.CategoryRepositoryTests
{
    [TestFixture]
    public class When_adding_a_Category_range : Given_a_CategoryRepository
    {
        private List<Category> _models;

        protected override void Given()
        {
            base.Given();

            _models = new List<Category>
            {
                new Category
                {
                    Name = "Test Category 1",
                    Description = "Test  Category 1",
                    ChildCategories = new List<Category>
                    {
                        new Category
                        {
                            Name = "Test Child Category 1.1",
                            Description = "Test Child Category 1.1",
                            ChildCategories = new List<Category>
                            {
                                new Category
                                {
                                    Name = "Test Grandchild Category 1.1.1",
                                    Description = "Test Grandchild Category 1.1.1"
                                },
                                new Category
                                {
                                    Name = "Test Grandchild Category 1.1.2",
                                    Description = "Test Grandchild Category 1.1.2"
                                }
                            }
                        },
                        new Category
                        {
                            Name = "Test Child Category 1.2",
                            Description = "Test Child Category 1.2",
                            ChildCategories = new List<Category>
                            {
                                new Category
                                {
                                    Name = "Test Grandchild Category 1.2.1",
                                    Description = "Test Grandchild Category 1.2.1"
                                },
                                new Category
                                {
                                    Name = "Test Grandchild Category 1.2.2",
                                    Description = "Test Grandchild Category 1.2.2"
                                }
                            }
                        }
                    }
                },
                new Category
                {
                    Name = "Test Category 2",
                    Description = "Test Parent Category 2",
                    ChildCategories = new List<Category>
                    {
                        new Category
                        {
                            Name = "Test Child Category 2.1",
                            Description = "Test Child Category 2.1",
                            ChildCategories = new List<Category>
                            {
                                new Category
                                {
                                    Name = "Test Grandchild Category 2.1.1",
                                    Description = "Test Grandchild Category 2.1.1"
                                },
                                new Category
                                {
                                    Name = "Test Grandchild Category 2.1.2",
                                    Description = "Test Grandchild Category 2.1.2"
                                }
                            }
                        },
                        new Category
                        {
                            Name = "Test Child Category 2.2",
                            Description = "Test Child Category 2.2",
                            ChildCategories = new List<Category>
                            {
                                new Category
                                {
                                    Name = "Test Grandchild Category 2.2.1",
                                    Description = "Test Grandchild Category 2.2.1"
                                },
                                new Category
                                {
                                    Name = "Test Grandchild Category 2.2.2",
                                    Description = "Test Grandchild Category 2.2.2"
                                }
                            }
                        }
                    }
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
            SUT.CountAsync().Result.ShouldBe(17);
        }
    }
}
