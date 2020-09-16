using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using Assignment.Dal;
using Assignment.DAL.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Api.Core.IToDoListService" />
    public class ToDoListService : IToDoListService
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
        /// Initializes a new instance of the <see cref="ToDoListService"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="mapper">The mapper.</param>
        public ToDoListService(IGenericRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets to do list.
        /// </summary>
        /// <param name="pagingDto">The paging dto.</param>
        /// <returns></returns>
        public List<ToDoListDTO> GetToDoList(PagingDTO pagingDto, long userId)
        {
            List<ToDoListEntity> filteredList = null;
            List<ToDoListDTO> _items = null;
            if (!string.IsNullOrEmpty(pagingDto.SearchString))
            {
                filteredList = _repo.GetWithCondition<ToDoListEntity>(x => x.CreatedBy == userId && x.Description.ToLower().Contains(pagingDto.SearchString.ToLower()));
            }
            else
            {
                filteredList = _repo.GetWithCondition<ToDoListEntity>(x => x.CreatedBy == userId);
            }
            if (pagingDto.PageSize > 0 && pagingDto.PageIndex > 0)
            {
                filteredList = filteredList.Skip((pagingDto.PageIndex - 1) * pagingDto.PageSize).Take(pagingDto.PageSize).ToList();
            }
            _items = _mapper.Map<List<ToDoListEntity>, List<ToDoListDTO>>(filteredList);
            return _items;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ToDoListDTO GetById(long id)
        {
            var entity = _repo.GetWithCondition<ToDoListEntity>(x => x.Id == id).FirstOrDefault();
            ToDoListDTO dto = _mapper.Map<ToDoListEntity, ToDoListDTO>(entity);
            return dto;
        }

        /// <summary>
        /// Adds to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        public ToDoListDTO AddToDoList(ToDoListDTO todolist)
        {

            ToDoListEntity entity = _mapper.Map<ToDoListDTO, ToDoListEntity>(todolist);
            entity.CreatedDate = DateTime.Now;
            _repo.Add(entity);
            return todolist;
        }

        /// <summary>
        /// Updates to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        public ToDoListDTO UpdateToDoList(ToDoListDTO todolist)
        {
            ToDoListEntity entity = _mapper.Map<ToDoListDTO, ToDoListEntity>(todolist);
            _repo.Update(entity, todolist.Id);
            return todolist;
        }

        /// <summary>
        /// Deletes to do list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteToDoList(int id)
        {
            _repo.Delete<ToDoListEntity>(id);
            return id;
        }

    }

}
