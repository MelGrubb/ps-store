using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public partial class CategoryBuilder
    {
        public static CategoryBuilder Simple()
        {
            return Default()
                .WithName(() => GetRandom.String(1, 50));
        }

        public static CategoryBuilder Typical()
        {
            return Simple()
                .WithDescription(() => GetRandom.String(1, 255))
                .WithChildCategories(() => Enumerable.Range(1, GetRandom.Int32(1, 10))
                    .Select(_ => Simple().Build()).ToList());
        }

        protected override void PostBuild(Category value)
        {
            foreach (var childCategory in value?.ChildCategories ?? Enumerable.Empty<Category>())
            {
                childCategory.ParentCategory = value;
                childCategory.ParentCategoryId = value?.Id;
            }
        }
    }
}
