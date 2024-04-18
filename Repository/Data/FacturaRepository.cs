using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaRepository
    {
        private readonly IDbConnection _conexionDB;

        public FacturaRepository(string connectionString)
        {
            _conexionDB = new DbConection(connectionString).dbConnection();
        }

        public bool Add(FacturaModel factura)
        {
            try
            {
                var query = "INSERT INTO Factura(NRO_FACTURA, FECHA_HORA, TOTAL, TOTAL_IVA, TOTAL_LETRAS, SUCURSAL) " +
                            "VALUES(@NroFactura, @FechaHora, @Total, @TotalIVA, @TotalLetras, @Sucursal)";
                var affectedRows = _conexionDB.Execute(query, factura);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(FacturaModel factura)
        {
            try
            {
                var query = "UPDATE Factura SET " +
                            "NRO_FACTURA=@NroFactura, " +
                            "FECHA_HORA=@FechaHora, " +
                            "TOTAL=@Total, " +
                            "TOTAL_IVA=@TotalIVA, " +
                            "TOTAL_LETRAS=@TotalLetras, " +
                            "SUCURSAL=@Sucursal " +
                            "WHERE id_factura = @Id";
                var affectedRows = _conexionDB.Execute(query, factura);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public FacturaModel get(int id)
        {
            try
            {
                var query = "SELECT * FROM Factura WHERE id_cliente = @Id";
                return _conexionDB.QueryFirstOrDefault<FacturaModel>(query, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<FacturaModel> list()
        {
            try
            {
                var query = "SELECT * FROM Factura";
                return _conexionDB.Query<FacturaModel>(query).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool remove(FacturaModel cliente)
        {
            try
            {
                var query = "DELETE FROM Factura WHERE id = @Id";
                var affectedRows = _conexionDB.Execute(query, cliente);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
