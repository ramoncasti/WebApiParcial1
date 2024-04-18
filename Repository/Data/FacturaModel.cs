using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public string NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIVA { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }
    }

}
