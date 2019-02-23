using Newtonsoft.Json;

namespace Store.Common.Validation
{
    public class ValidationError
    {
        /// <summary>Initializes a new instance of the <see cref="ValidationError" /> class.</summary>
        /// <param name="key">The Key value.</param>
        /// <param name="message">The Message value.</param>
        public ValidationError(string key, string message)
        {
            Key = key != string.Empty ? key : null;
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        public string Message { get; }
    }
}
