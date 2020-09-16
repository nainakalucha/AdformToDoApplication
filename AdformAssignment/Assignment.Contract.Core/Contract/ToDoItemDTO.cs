
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Contract.Core.BaseDTO" />
    public class ToDoItemDTO: BaseDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }
        /// <summary>
        /// Converts to dolistid.
        /// </summary>
        /// <value>
        /// To do list identifier.
        /// </value>
        public Int64 ToDoListId { get; set; }
        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; }
        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        /// <value>
        /// The label identifier.
        /// </value>
        public Int64 LabelId { get; set; }
    }
 }
