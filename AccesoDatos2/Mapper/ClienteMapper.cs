using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Mapper
{
    public class ClienteMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "Id_Cliente";
        private const string DB_COL_CEDULA = "Cedula"; 
        private const string DB_COL_NOMBRE = "Nombre";
        private const string DB_COL_APELLIDO = "Apellido";
        private const string DB_COL_FECHANAC = "FechaNac";
        private const string DB_COL_EDAD = "Edad";

        //esto arregla que el objeto var cliente no salga como error
        internal object GetCreateStatement(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        private const string DB_COL_ESTADOCIVIL = "EstadoCivil";
        private const string DB_COL_GENERO = "Genero";
        private const string DB_COL_DIRECCION = "Direccion";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cliente);
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddDateTimeParam(DB_COL_FECHANAC, c.FechaNac);
            operation.AddIntParam(DB_COL_EDAD, c.Edad);
            operation.AddVarcharParam(DB_COL_ESTADOCIVIL, c.EstadoCivil);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddIntParam(DB_COL_DIRECCION, c.Direccion);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cliente);

            return operation;
        }

        internal SqlOperation GetUpdateStatement(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        internal SqlOperation GetDeleteStatement(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CLIENTES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cliente);
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddDateTimeParam(DB_COL_FECHANAC, c.FechaNac);
            operation.AddIntParam(DB_COL_EDAD, c.Edad);
            operation.AddVarcharParam(DB_COL_ESTADOCIVIL, c.EstadoCivil);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddIntParam(DB_COL_DIRECCION, c.Direccion);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cliente);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cliente = new Cliente
            {
                Id_Cliente = GetIntValue(row, DB_COL_ID),
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO),
                FechaNac = GetDateValue(row, DB_COL_FECHANAC),
                Edad = GetIntValue(row, DB_COL_EDAD),
                EstadoCivil = GetStringValue(row, DB_COL_ESTADOCIVIL),
                Genero= GetStringValue(row, DB_COL_GENERO),
                Direccion = GetIntValue(row, DB_COL_DIRECCION)
            };

            return cliente;
        }

        
    }
}
