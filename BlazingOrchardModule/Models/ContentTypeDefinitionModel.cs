using System.Collections.Generic;

namespace BlazingOrchardModule.Models
{
    public class ContentTypeDefinitionModel : ContentDefinitionModel
    {
        public ICollection<ContentTypePartDefinitionModel> Parts { get; set; } = default!;
    }
}