using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILabelClient
    {
        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <returns></returns>
        [Get("/api/label")]
        Task<HttpResponseMessage> GetLabels();

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        [Post("/api/label")]
        Task<HttpResponseMessage> AddLabel(LabelDTO label);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Delete("/api/label")]
        Task<HttpResponseMessage> DeleteLabel(int id);
    }
}
