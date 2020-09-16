using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using Assignment.DAL.Core;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Api.Core.IToDoItemService" />
    public class ToDoItemService : IToDoItemService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The repo
        /// </summary>
        private readonly IGenericRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoItemService"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="mapper">The mapper.</param>
        public ToDoItemService(IGenericRepository repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets to do item.
        /// </summary>
        /// <param name="pagingDto"></param>
        /// <returns></returns>
        public List<ToDoItemDTO> GetToDoItem(PagingDTO pagingDto, long userId)
        {
            List<ToDoItemEntity> filteredList = null;
            List<ToDoItemDTO>  _items = null;
            if (!string.IsNullOrEmpty(pagingDto.SearchString))
            {
                filteredList = _repo.GetWithCondition<ToDoItemEntity>(x =>x.CreatedBy == userId && x.Note.ToLower().Contains(pagingDto.SearchString.ToLower()));
            }
            else
            {
                filteredList = _repo.GetWithCondition<ToDoItemEntity>(x=>x.CreatedBy == userId);
            }
            if (pagingDto.PageSize > 0 && pagingDto.PageIndex > 0)
            {
                filteredList = filteredList.Skip((pagingDto.PageIndex - 1) * pagingDto.PageSize).Take(pagingDto.PageSize).ToList();
            }
            _items = _mapper.Map<List<ToDoItemEntity>, List<ToDoItemDTO>>(filteredList);
            return _items;
        }


        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ToDoItemDTO GetById(long id)
        {
            var entity = _repo.GetWithCondition<ToDoItemEntity>(x => x.Id == id).FirstOrDefault();
            ToDoItemDTO dtdo = _mapper.Map<ToDoItemEntity, ToDoItemDTO>(entity);
            return dtdo;
        }
        /// <summary>
        /// Adds to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        public ToDoItemDTO AddToDoItem(ToDoItemDTO ToDoItem)
        {
            ToDoItemEntity entity = _mapper.Map<ToDoItemDTO, ToDoItemEntity>(ToDoItem);
            _repo.Add(entity);
            return ToDoItem;
        }

        /// <summary>
        /// Updates to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        public ToDoItemDTO UpdateToDoItem(ToDoItemDTO ToDoItem)
        {
            ToDoItemEntity entity = _mapper.Map<ToDoItemDTO, ToDoItemEntity>(ToDoItem);
            _repo.Update(entity, ToDoItem.Id);
            return ToDoItem;
        }

        /// <summary>
        /// Deletes to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteToDoItem(int id)
        {
            _repo.Delete<ToDoItemEntity>(id);
            return id;
        }

    }

}
