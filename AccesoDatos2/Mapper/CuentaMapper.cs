using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Mapper
{
    public class CuentaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "Id_Cuenta";
        private const string DB_COL_NOMBRE = "Nombre";
        private const string DB_COL_MONEDA = "Moneda";
        private const string DB_COL_SALDO = "Saldo";
        private const string DB_COL_CLIENTE = "Cliente";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CUENTA_PR" };

            var c = (Cuenta)entity;
            //operation.AddIntParam(DB_COL_ID, c.Id_Cuenta);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);
            operation.AddIntParam(DB_COL_CLIENTE, c.Cliente);

            return operation;
        }

      
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cuenta);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUENTAS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cuenta);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);
            operation.AddIntParam(DB_COL_CLIENTE, c.Cliente);

            return operation;
        }

        

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Cuenta);
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
            var cuenta = new Cuenta
            {
                Id_Cuenta = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Moneda = GetStringValue(row, DB_COL_MONEDA),
                Saldo = (float)GetDoubleValue(row, DB_COL_SALDO),
                Cliente = GetIntValue(row, DB_COL_CLIENTE)
            };

            return cuenta;
        }


    }
}
