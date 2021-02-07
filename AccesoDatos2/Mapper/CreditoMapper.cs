using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Mapper
{
    public class CreditoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "Id_Credito";
        private const string DB_COL_MONTO = "Monto";
        private const string DB_COL_TASA = "Tasa";
        private const string DB_COL_NOMBRE = "Nombre";
        private const string DB_COL_CUOTA = "Cuota";
        private const string DB_COL_FECHAINICIO = "FechaInicio";
        private const string DB_COL_ESTADO = "Estado";
        private const string DB_COL_SALDOOPERACION = "SaldoOperacion";
        private const string DB_COL_CLIENTE = "Cliente";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Credito);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddDateTimeParam(DB_COL_FECHAINICIO, c.FechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDOOPERACION, c.SaldoOperacion);
            operation.AddIntParam(DB_COL_CLIENTE, c.Cliente);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Credito);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITOS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Credito);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddDateTimeParam(DB_COL_FECHAINICIO, c.FechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDOOPERACION, c.SaldoOperacion);
            operation.AddIntParam(DB_COL_CLIENTE, c.Cliente);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Credito);
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
            var credito = new Credito
            {
                Id_Credito = GetIntValue(row, DB_COL_ID),
                Monto = (float)GetDoubleValue(row, DB_COL_MONTO),
                Tasa = (float)GetDoubleValue(row, DB_COL_TASA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cuota = (float)GetDoubleValue(row, DB_COL_CUOTA),
                FechaInicio = GetDateValue(row, DB_COL_FECHAINICIO),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                SaldoOperacion = (float)GetDoubleValue(row, DB_COL_SALDOOPERACION),
                Cliente = GetIntValue(row, DB_COL_CLIENTE)
            };

            return credito;
        }


    }
}
