using System;
using System.Linq;
using Humanizer;

namespace Store.Common.Validation
{
    public static class ValidationHelper
    {
        public const string KeyDoesNotMatchRoute = "{0} does not match route";

        /// <summary>Tests the supplied validation conditions and throws an ApiException if appropriate.</summary>
        /// <param name="values">An array of <see cref="Tuple" />s containing conditions, keys, and messages for evaluation.</param>
        /// <remarks>
        ///     Within each <see cref="Tuple" /> in <paramref name="values" />, the elements are used as follow.
        ///     <see cref="bool" /> isValid - A boolean representing the condition.
        ///     <see cref="string" /> key - The path and/or name of the field that is being validated.
        ///     <see cref="string" /> message - A message to display if the validation fails.
        /// </remarks>
        public static void Validate(params Tuple<bool, string, string>[] values)
        {
            var errors = values.Where(value => !value.Item1)
                .Select(value => new ValidationError(value.Item2, value.Item3))
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        /// <summary>Tests the supplied validation condition and throws an ApiException if appropriate.</summary>
        /// <param name="isValid">A boolean representing the condition.</param>
        /// <param name="key">The path and/or name of the field that is being validated.</param>
        /// <param name="message">A message to display if the validation fails.</param>
        public static void Validate(bool isValid, string key, string message)
        {
            message = message == null ? null : string.Format(message, key.Humanize());
            Validate(new Tuple<bool, string, string>(isValid, key, message));
        }
    }
}
