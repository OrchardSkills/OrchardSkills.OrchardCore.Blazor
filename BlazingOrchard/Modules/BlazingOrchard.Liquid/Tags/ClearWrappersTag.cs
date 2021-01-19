using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BlazingOrchard.DisplayManagement.Shapes;
using Fluid;
using Fluid.Ast;
using Fluid.Tags;

namespace BlazingOrchard.Liquid.Tags
{
    public class ClearWrappers : ExpressionTag
    {
        public override async ValueTask<Completion> WriteToAsync(TextWriter writer, TextEncoder encoder, TemplateContext context, Expression expression)
        {
            var objectValue = (await expression.EvaluateAsync(context)).ToObjectValue();

            if (objectValue is IShape shape)
            {
                shape.Metadata.Wrappers.Clear();
            }

            return Completion.Normal;
        }
    }
}
