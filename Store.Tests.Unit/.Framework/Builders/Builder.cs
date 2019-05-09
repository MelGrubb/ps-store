using System;

namespace Store.Tests.Unit.Framework.Builders
{
    public abstract class Builder<T> where T : class
    {
        protected Lazy<T> Object;

        public abstract T Build();

        public Builder<T> WithObject(T value)
        {
            return WithObject(() => value);
        }

        public Builder<T> WithObject(Func<T> func)
        {
            Object = new Lazy<T>(func);
            return this;
        }

        protected virtual void PostBuild(T value)
        {

        }
    }
}
