using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
