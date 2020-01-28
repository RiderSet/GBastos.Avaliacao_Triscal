using CRUD.ApplicationCore.Entities;
using CRUD.ApplicationCore.Interfaces;
using CRUD.ApplicationCore.Interfaces.Repositories;
using CRUD.InfraEstructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUD.InfraEstructure.Repositories
{
    public class Endereco_Rep : Base_Rep, IEndereco_Rep
    {
        public Endereco_Rep(Context context) : base(context) { }

        public async Task Add_Async(Endereco endereco)
        {
            await CTX.Enderecos.AddAsync(endereco);
        }

        public async Task<Endereco> ById_Async(long id)
        {
            return await CTX.Enderecos.FindAsync(id);
        }

        public async Task<IEnumerable<Endereco>> lst_AllAync()
        {
            return await CTX.Enderecos.ToListAsync();
        }

        public async Task<IEnumerable<Endereco>> lst_ByClienteAync(Cliente cliente)
        {
            List<Endereco> ends = await CTX.Enderecos.Where(x => x.ClienteId == cliente.Id).ToListAsync();
            if (ends.Count() >= 1)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não foi encontrado endereço associado ao cliente {0}", cliente.Nome)),
                    ReasonPhrase = "Cliente sem endeereço associado"
                };
                throw new ArgumentException($"O cliente {cliente.Nome} está sem endeerços associados.", nameof(cliente.Nome));
            }
            return ends;
        }

        public void RemoveAsync(Endereco endereco)
        {
            CTX.Enderecos.Remove(endereco);
        }

        public async Task UpDateAsync(Endereco endereco)
        {
            await CTX.Enderecos.AddAsync(endereco);
        }
    }
}
