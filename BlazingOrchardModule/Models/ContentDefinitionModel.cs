using Newtonsoft.Json.Linq;

namespace BlazingOrchardModule.Models
{
    public abstract class ContentDefinitionModel
    {
        public string Name { get; set; } = default!;
        public JObject? Settings { get; set; } = new JObject();
    }
}