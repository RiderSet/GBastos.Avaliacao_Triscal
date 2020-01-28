using CRUD.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces.Repositories
{
    public interface ICliente_Rep : IRep_Base<Cliente>
    {
        Task<Cliente> lst_ByEnderecoAync(Endereco endereco);
    }
}
