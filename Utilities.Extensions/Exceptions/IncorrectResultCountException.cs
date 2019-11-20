using System;
using Repository.Core;

namespace Utilities.Extensions.Exceptions
{
    [Serializable]
    public class IncorrectResultCountException : Exception
    {
        public static IncorrectResultCountException Constructor<T>(int expectedCount, int actualCount,
            bool perfectMatch = false) where T : class, IEntity
        {
            bool toMany = false;
            switch (perfectMatch)
            {
                case true:
                    if (expectedCount < actualCount) toMany = true;
                    return new IncorrectResultCountException(
                            $"Expected to find exactly {expectedCount}, but actually found {actualCount} of the entity type {typeof(T).Name}")
                        {ActualCount = actualCount, ExpectedCount = expectedCount, ToMany = toMany};
                case false:
                    return new IncorrectResultCountException(
                            $"Expected to find at least {expectedCount}, but actually found {actualCount} of the entity type {typeof(T).Name}")
                        {ActualCount = actualCount, ExpectedCount = expectedCount};
            }
        }

        public int ExpectedCount { get; private set; }
        public int ActualCount { get; private set; }
        public bool ToMany { get; private set; }
        public bool ToFew{ get
            {
                return !ToMany;
            }
        }

        protected IncorrectResultCountException(string message) : base(message)
        {

        }

    }
}