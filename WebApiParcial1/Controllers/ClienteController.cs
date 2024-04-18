using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;

namespace WebApiParcial1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> GetClientes()
        {
            try
            {
                var clientes = _clienteRepository.list();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ClienteModel> CreateCliente(ClienteModel cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("El cliente no puede ser nulo.");
                }

                _clienteRepository.add(cliente);
                return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteModel> UpdateCliente(int id, ClienteModel cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return BadRequest("IDs no coinciden.");
                }

                var existingCliente = _clienteRepository.get(id);
                if (existingCliente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                _clienteRepository.update(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(int id)
        {
            try
            {
                var existingCliente = _clienteRepository.get(id);
                if (existingCliente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                _clienteRepository.remove(existingCliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
