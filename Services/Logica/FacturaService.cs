using System;
using System.Text.RegularExpressions;
using Repository.Data;

namespace Services.Logica
{
    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(string connectionString)
        {
            _facturaRepository = new FacturaRepository(connectionString);
        }

        public bool Add(FacturaModel factura)
        {
            if (ValidacionFactura(factura))
            {
                return _facturaRepository.Add(factura);
            }
            else
            {
                return false;
            }
        }


        private bool ValidacionFactura(FacturaModel factura)
        {
            if (factura == null)
            {
                return false;
            }

            // Validación del número de factura
            if (!Regex.IsMatch(factura.NroFactura.ToString(), @"^\d{3}-\d{3}-\d{6}$"))
            {
                return false;
            }

            // Validación de campos numéricos obligatorios
            if (factura.Total <= 0 || factura.TotalIVA <= 0)
            {
                return false;
            }

            // Validación total en letras
            if (string.IsNullOrEmpty(factura.TotalLetras) || factura.TotalLetras.Length < 6)
            {
                return false;
            }

            return true;
        }
    }
}
