﻿using AccesoDatos.DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Mapper
{
    public class DireccionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "Id_Direccion";
        private const string DB_COL_PROVINCIA = "Provincia";
        private const string DB_COL_CANTON = "Canton";
        private const string DB_COL_DISTRITO = "Distrito";
        private const string DB_COL_CLIENTE = "Cliente";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCION_PR" };

            var c = (Direccion)entity;
            //operation.AddIntParam(DB_COL_ID, c.Id_Direccion);
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddIntParam(DB_COL_CLIENTE, c.Cliente);

            return operation;
        }

        //DEVUELVE EL PROCEDURE DE IDENTITY ID
        public SqlOperation GetRetriveIdentity()
        {
            var operation = new SqlOperation { ProcedureName = "IDENTITY_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Direccion);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCIONES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Direccion);
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_ID, c.Id_Direccion);
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
            var direccion = new Direccion
            {
                Id_Direccion = GetIntValue(row, DB_COL_ID),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton= GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Cliente = GetIntValue(row,DB_COL_CLIENTE)
                
            };

            return direccion;
        }


    }
}
