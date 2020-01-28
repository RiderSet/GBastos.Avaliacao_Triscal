using CRUD.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces.Services
{
    public interface IEndereco_SRV : ISrv_Base<Endereco>
    {
        Task<IEnumerable<Endereco>> lst_ByCliente(Cliente cliente);
    }
}
