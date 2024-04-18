using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private readonly IDbConnection _conexionDB;

        public ClienteRepository(string connectionString)
        {
            _conexionDB = new DbConection(connectionString).dbConnection();
        }

        public bool add(ClienteModel cliente)
        {
            try
            {
                var query = "INSERT INTO Cliente(nombre, apellido, documento, direccion, celular, estado) " +
                            "VALUES(@Nombre, @Apellido, @Documento, @Direccion, @Celular, @Estado)";
                var affectedRows = _conexionDB.Execute(query, cliente);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool update(ClienteModel cliente)
        {
            try
            {
                var query = "UPDATE Cliente SET " +
                            "nombre=@Nombre, " +
                            "apellido=@Apellido, " +
                            "documento=@Documento, " +
                            "direccion=@Direccion, " +
                            "mail=@Mail, " +
                            "celular=@Celular, " +
                            "estado=@Estado " +
                            "WHERE id_cliente = @Id";
                var affectedRows = _conexionDB.Execute(query, cliente);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClienteModel get(int id)
        {
            try
            {
                var query = "SELECT * FROM Cliente WHERE id_cliente = @Id";
                return _conexionDB.QueryFirstOrDefault<ClienteModel>(query, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClienteModel> list()
        {
            try
            {
                var query = "SELECT * FROM Cliente";
                return _conexionDB.Query<ClienteModel>(query).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool remove(ClienteModel cliente)
        {
            try
            {
                var query = "DELETE FROM Cliente WHERE id_cliente = @Id";
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
