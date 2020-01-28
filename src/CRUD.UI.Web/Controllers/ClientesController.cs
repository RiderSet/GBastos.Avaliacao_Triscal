using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.ApplicationCore.Entities;
using CRUD.ApplicationCore.Interfaces;
using CRUD.ApplicationCore.Interfaces.Services;
using CRUD.InfraEstructure.Data.Contexts;

namespace CRUD.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente_SRV _context;
        //private readonly Context _ctx;

        public ClientesController(ICliente_SRV context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            var clientes = await _context.lst_All();
            return clientes;
        }

        // GET: api/Clientes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            Cliente cliente = await _context.ById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        // GET: api/Clientes/Ouvidor
        [HttpGet("{endereco}")]
        public async Task<ActionResult<Cliente>> GetCliente(Endereco endereco)
        {
            Cliente cliente = await _context.lst_ByEndereco(endereco);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente([FromRoute] int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _context.UpDateAsync(cliente);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Add(cliente);
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);

        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(long id)
        {
            var cliente = await _context.ById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            return cliente;
        }

        private async Task<bool> ClienteExistsAsync(long id)
        {
            var cliente = await _context.ById(id);
            if (cliente == null)
            {
                return false;
            }
            return true;
        }
    }
}
