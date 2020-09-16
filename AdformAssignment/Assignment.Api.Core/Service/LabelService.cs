using Assignment.Contract.Core;
using Assignment.DAL.Core;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Api.Core.ILabelService" />
    public class LabelService : ILabelService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        private readonly IGenericRepository _repo;

        public LabelService(IGenericRepository repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <returns></returns>
        public List<LabelDTO> GetLabels()
        {
            List<LabelDTO> _labels = null;
            var labelList = _repo.Get<LabelEntity>();
            _labels = _mapper.Map<List<LabelEntity>, List<LabelDTO>>(labelList);
            return _labels;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public LabelDTO AddLabel(LabelDTO label)
        {
            LabelEntity labelEntity = _mapper.Map<LabelDTO, LabelEntity>(label);
            labelEntity.CreatedDate = DateTime.Now;
            _repo.Add(labelEntity);
            return label;
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteLabel(int id)
        {
            _repo.Delete<LabelEntity>(id);
            return id;
        }

    }

}
