using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces.Services
{
    public interface ISrv_Base<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> lst_All();
        Task Add(TEntity Entity);
        Task<TEntity> ById(long id);

        //void UpDate(TEntity Entity);
        Task UpDateAsync(TEntity Entity);
        void Remove(TEntity Entity);
    }
}
