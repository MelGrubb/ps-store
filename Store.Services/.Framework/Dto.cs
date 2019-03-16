using Newtonsoft.Json;

namespace Store.Services.Framework
{
    /// <summary>Base object for all service entities.</summary>
    /// <remarks>This is a simple base class to make it easy to separate the entities from other contracts.</remarks>
    public abstract class Dto
    {
        [JsonProperty(Order = int.MinValue)]
        public int Id { get; set; }
    }
}
