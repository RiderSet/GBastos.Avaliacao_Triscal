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
    public class Cliente_Rep : Base_Rep, ICliente_Rep
    {
        public Cliente_Rep(Context context) : base(context) { }

        public async Task Add_Async(Cliente cliente)
        {
            await CTX.Clientes.AddAsync(cliente);
        }

        public async Task<Cliente> ById_Async(long id)
        {
            return await CTX.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> lst_AllAync()
        {
            return await CTX.Clientes.ToListAsync();
        }

        public async Task<Cliente> lst_ByEnderecoAync(Endereco endereco)
        {
            Cliente cli = await CTX.Clientes.FirstAsync(x => x.Id == endereco.ClienteId);
            if (cli == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não foi encontrado cliente com o endereço {0}", endereco.Logradouro)),
                    ReasonPhrase = "Cliente não encontrado"
                };
                throw new ArgumentException(
            $"Sem resposta para {endereco.Logradouro}.", nameof(endereco.Logradouro)); ;
            }
            return cli;
        }

        public void RemoveAsync(Cliente cliente)
        {
            CTX.Clientes.Remove(cliente);
            CTX.SaveChanges();
        }

        //void IRep_Base<Cliente>.UpDateAsync(Cliente Entity)
        public async Task UpDateAsync(Cliente cliente)
        {
            CTX.Entry(cliente).State = EntityState.Modified;

            try
            {
                await CTX.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    throw new ArgumentException(
            $"Nada encontrado para o cliente {cliente.Nome}.", nameof(cliente.Nome));

                }
                else
                {
                    throw;
                }
            }

        }

        private bool ClienteExists(long id)
        {
            return CTX.Clientes.Any(e => e.Id == id);
        }
    }
}
