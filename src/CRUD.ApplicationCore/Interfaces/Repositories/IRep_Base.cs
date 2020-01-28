using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces
{
    public interface IRep_Base<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> lst_AllAync();
        Task Add_Async(TEntity Entity);
        Task<TEntity> ById_Async(long id);

        Task UpDateAsync(TEntity Entity);
        //Task UpDateAsync(Cliente cliente)

        void RemoveAsync(TEntity Entity);
    }
}
