using System;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Contract.Core.BaseDTO" />
    public class ToDoListDTO: BaseDTO
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
        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        /// <value>
        /// The label identifier.
        /// </value>
        public Int64 LabelId { get; set; }
    }
 }
