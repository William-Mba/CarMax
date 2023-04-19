using CarMax.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarMax.Application.Interfaces
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(string id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
