using Assignment.DAL.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Assignment.Dal
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AssignmentSqlDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentSqlDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AssignmentSqlDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<UserEntity> Users { get; set; }
        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public DbSet<LabelEntity> Labels { get; set; }
        /// <summary>
        /// Converts to doitems.
        /// </summary>
        /// <value>
        /// To do items.
        /// </value>
        public DbSet<ToDoItemEntity> ToDoItems { get; set; }
        /// <summary>
        /// Converts to dolist.
        /// </summary>
        /// <value>
        /// To do list.
        /// </value>
        public DbSet<ToDoListEntity> ToDoList { get; set; }
    }
}
