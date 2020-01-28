using CRUD.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces.Services
{
    public interface ICliente_SRV : ISrv_Base<Cliente>
    {
        Task<Cliente> lst_ByEndereco(Endereco endereco);
    }
}
