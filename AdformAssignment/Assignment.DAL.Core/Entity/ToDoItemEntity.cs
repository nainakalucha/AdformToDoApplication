using Assignment.DAL.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DAL.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.DAL.Core.Entity.BaseEntity" />
    [Table("ToDoItem")]
    public class ToDoItemEntity: BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Column("Id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// Converts to dolistid.
        /// </summary>
        /// <value>
        /// To do list identifier.
        /// </value>
        [Column("ToDoListId")]
        public Int64 ToDoListId { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        [Column("Note")]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        /// <value>
        /// The label identifier.
        /// </value>
        [Column("LabelId")]
        public Int64 LabelId { get; set; }
    }
 }
