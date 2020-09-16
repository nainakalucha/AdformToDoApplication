using HotChocolate.Types;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotChocolate.Types.ObjectType{Assignment.Api.Core.AssessmentQuery}" />
    public class AssessmentQueryType : ObjectType<AssessmentQuery>
    {
        /// <summary>
        /// Configures the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        protected override void Configure(IObjectTypeDescriptor<AssessmentQuery> descriptor)
        {
            base.Configure(descriptor);

            descriptor
        .Field(f => f.GetToDoItems(null, null));

            descriptor
       .Field(f => f.GetToDoList(null, null));

            descriptor
        .Field(f => f.GetLabels());
        }
    }
}
