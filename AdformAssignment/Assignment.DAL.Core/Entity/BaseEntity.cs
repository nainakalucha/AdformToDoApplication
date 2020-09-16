using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DAL.Core.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [Column("CreatedBy")]
        public Int64? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        [Column("UpdatedBy")]
        public Int64? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }
}
