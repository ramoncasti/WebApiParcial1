using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiParcial1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaController(FacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository ?? throw new ArgumentNullException(nameof(facturaRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<FacturaModel>> GetFacturas()
        {
            try
            {
                var facturas = _facturaRepository.list();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FacturaModel> GetFactura(int id)
        {
            try
            {
                var factura = _facturaRepository.get(id);
                if (factura == null)
                {
                    return NotFound();
                }
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<FacturaModel> CreateFactura(FacturaModel factura)
        {
            try
            {
                if (factura == null)
                {
                    return BadRequest("La factura no puede ser nula.");
                }

                _facturaRepository.Add(factura);
                return CreatedAtAction(nameof(GetFacturas), new { id = factura.NroFactura }, factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFactura(int id, FacturaModel factura)
        {
            try
            {
                if (id != factura.Id)
                {
                    return BadRequest("IDs no coinciden.");
                }

                var existingFactura = _facturaRepository.get(id);
                if (existingFactura == null)
                {
                    return NotFound("Factura no encontrada.");
                }

                _facturaRepository.Update(factura);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFactura(int id)
        {
            try
            {
                var existingFactura = _facturaRepository.get(id);
                if (existingFactura == null)
                {
                    return NotFound("Factura no encontrada.");
                }

                _facturaRepository.remove(existingFactura);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
