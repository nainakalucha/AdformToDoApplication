using Assignment.Contract.Core;
using System.Collections.Generic;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILabelService
    {
        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <returns></returns>
        List<LabelDTO> GetLabels();

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        LabelDTO AddLabel(LabelDTO label);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int DeleteLabel(int id);
    }
}
