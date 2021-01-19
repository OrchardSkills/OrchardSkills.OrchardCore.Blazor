using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BlazingOrchard.DisplayManagement.Shapes;
using BlazingOrchard.Liquid.Ast;
using Fluid;
using Fluid.Ast;
using Fluid.Values;

namespace BlazingOrchard.Liquid.Tags
{
    public class AddAlternatesTag : ExpressionArgumentsTag
    {
        public override async ValueTask<Completion> WriteToAsync(TextWriter writer, TextEncoder encoder, TemplateContext context, Expression expression, FilterArgument[] args)
        {
            var objectValue = (await expression.EvaluateAsync(context)).ToObjectValue();

            if (objectValue is IShape shape)
            {
                var arguments = (FilterArguments)(await new ArgumentsExpression(args).EvaluateAsync(context)).ToObjectValue();

                var alternates = arguments["alternates"].Or(arguments.At(0));

                if (alternates.Type == FluidValues.String)
                {
                    var values = alternates.ToStringValue().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var value in values)
                    {
                        shape.Metadata.Alternates.Add(value);
                    }
                }
                else if (alternates.Type == FluidValues.Array)
                {
                    foreach (var value in alternates.Enumerate())
                    {
                        shape.Metadata.Alternates.Add(value.ToStringValue());
                    }
                }
            }

            return Completion.Normal;
        }
    }
}
