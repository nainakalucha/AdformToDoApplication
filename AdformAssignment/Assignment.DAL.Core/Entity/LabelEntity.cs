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
    [Table("Label")]
    public class LabelEntity: BaseEntity
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
 }
