using CRUD.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Interfaces.Repositories
{
    public interface IEndereco_Rep : IRep_Base<Endereco>
    {
        Task<IEnumerable<Endereco>> lst_ByClienteAync(Cliente cliente);
    }
}
