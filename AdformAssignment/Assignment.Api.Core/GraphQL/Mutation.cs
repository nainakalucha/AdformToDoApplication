using Assignment.Contract.Core;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Mutation
    {
        /// <summary>
        /// The label service
        /// </summary>
        private readonly ILabelService _labelService;
        /// <summary>
        /// The todo item service
        /// </summary>
        private readonly IToDoItemService _todoItemService;
        /// <summary>
        /// The todo list service
        /// </summary>
        private readonly IToDoListService _todoListService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mutation"/> class.
        /// </summary>
        /// <param name="labelService">The label service.</param>
        /// <param name="todoItemService">The todo item service.</param>
        /// <param name="todolistservice">The todolistservice.</param>
        public Mutation(ILabelService labelService, IToDoItemService todoItemService, IToDoListService todolistservice)
        {
            _labelService = labelService;
            _todoItemService = todoItemService;
            _todoListService = todolistservice;
        }

        #region Label
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public LabelDTO AddLabel(LabelDTO label)
        {
            return _labelService.AddLabel(label);
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteLabel(int id)
        {
            return _labelService.DeleteLabel(id);
        }
        #endregion

        #region ToDoItem
        /// <summary>
        /// Adds to do item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ToDoItemDTO AddToDoItem(ToDoItemDTO item)
        {
            return _todoItemService.AddToDoItem(item);
        }

        /// <summary>
        /// Updates to do item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ToDoItemDTO UpdateToDoItem(ToDoItemDTO item)
        {
            return _todoItemService.UpdateToDoItem(item);
        }

        /// <summary>
        /// Deletes to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteToDoItem(int id)
        {
            return _todoItemService.DeleteToDoItem(id);
        }
        #endregion

        #region ToDoList
        /// <summary>
        /// Adds to do list.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ToDoListDTO AddToDoList(ToDoListDTO item)
        {
            return _todoListService.AddToDoList(item);
        }

        /// <summary>
        /// Updates to do list.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ToDoListDTO UpdateToDoList(ToDoListDTO item)
        {
            return _todoListService.UpdateToDoList(item);
        }

        /// <summary>
        /// Deletes to do list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteToDoList(int id)
        {
            return _todoListService.DeleteToDoList(id);
        }
        #endregion
    }
}
