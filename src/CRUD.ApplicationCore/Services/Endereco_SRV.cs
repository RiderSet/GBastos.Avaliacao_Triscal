using CRUD.ApplicationCore.Entities;
using CRUD.ApplicationCore.Interfaces.Repositories;
using CRUD.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.ApplicationCore.Services
{
    public class Endereco_SRV : IEndereco_SRV
    {
        private readonly IEndereco_Rep Endereco_Rep;

        public Endereco_SRV(IEndereco_Rep _Endereco_Rep)
        {
            Endereco_Rep = _Endereco_Rep;
        }

        public async Task Add(Endereco endereco)
        {
            await Endereco_Rep.Add_Async(endereco);
        }

        public async Task<Endereco> ById(long id)
        {
            var endereco = await Endereco_Rep.ById_Async(id); 
            return endereco;
        }

        public async Task<IEnumerable<Endereco>> lst_All()
        {
            return await Endereco_Rep.lst_AllAync();
        }

        public async Task<IEnumerable<Endereco>> lst_ByCliente(Cliente cliente)
        {
            var endereco = await Endereco_Rep.lst_ByClienteAync(cliente);
            return endereco;
        }

        public void Remove(Endereco endereco)
        {
            Endereco_Rep.RemoveAsync(endereco);
        }

        public void UpDate(Endereco endereco)
        {
        }

        public Task UpDateAsync(Endereco endereco)
        {
            return Endereco_Rep.UpDateAsync(endereco);
        }
    }
}
