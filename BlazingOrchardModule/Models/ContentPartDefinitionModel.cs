using System.Collections.Generic;

namespace BlazingOrchardModule.Models
{
    public class ContentPartDefinitionModel : ContentDefinitionModel
    {
        public ICollection<ContentPartFieldDefinitionModel> Fields { get; set; } = default!;
    }
}