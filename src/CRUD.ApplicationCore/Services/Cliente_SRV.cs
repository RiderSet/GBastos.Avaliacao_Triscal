using CRUD.ApplicationCore.Entities;
using CRUD.ApplicationCore.Interfaces.Repositories;
using CRUD.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Services
{
    public class Cliente_SRV : ICliente_SRV
    {
        private readonly ICliente_Rep Cliente_Rep;

        public Cliente_SRV(ICliente_Rep _Cliente_Rep)
        {
            Cliente_Rep = _Cliente_Rep;
        }

        public async Task Add(Cliente cliente)
        {
            await Cliente_Rep.Add_Async(cliente);
        }

        public async Task<Cliente> ById(long id)
        {
            Cliente cliente = await Cliente_Rep.ById_Async(id);
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> lst_All()
        {
            return await Cliente_Rep.lst_AllAync();
        }

        public async Task<Cliente> lst_ByEndereco(Endereco endereco)
        {
            Cliente cliente = await Cliente_Rep.lst_ByEnderecoAync(endereco);
            return cliente;
        }

        public void Remove(Cliente cliente)
        {
            Cliente_Rep.RemoveAsync(cliente);
        }

        public Task UpDateAsync(Cliente cliente)
        {
            return Cliente_Rep.UpDateAsync(cliente);
        }
    }
}
