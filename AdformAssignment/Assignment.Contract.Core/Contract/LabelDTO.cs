using System;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Contract.Core.BaseDTO" />
    public class LabelDTO: BaseDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
 }
