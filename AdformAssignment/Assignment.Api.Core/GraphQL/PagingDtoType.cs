using Assignment.Contract.Core.Contract;
using HotChocolate.Types;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="HotChocolate.Types.ObjectType{Assignment.Contract.Core.Contract.PagingDTO}" />
    public class PagingDtoType : ObjectType<PagingDTO>
    {
        /// <summary>
        /// Configures the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        protected override void Configure(IObjectTypeDescriptor<PagingDTO> descriptor)
        {
            descriptor.Field(a => a.PageIndex).Type<IdType>();
            descriptor.Field(a => a.PageSize).Type<IdType>();
            descriptor.Field(a => a.SearchString).Type<StringType>();
        }
    }
}
