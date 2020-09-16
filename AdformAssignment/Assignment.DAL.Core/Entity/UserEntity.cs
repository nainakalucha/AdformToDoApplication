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
    [Table("User")]
    public class UserEntity: BaseEntity
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
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [Column("Username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Column("Password")]
        public string Password { get; set; }
    }
 }
