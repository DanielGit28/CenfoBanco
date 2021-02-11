using AccesoDatos.DAO;
using AccesoDatos.Mapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Crud
{
    public class ClienteCrudFactory : CrudFactory
    {
        ClienteMapper mapper;

        public ClienteCrudFactory() : base()
        {
            mapper = new ClienteMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var cliente = (Cliente)entity;
            var sqlOperation = mapper.GetCreateStatement(cliente);
            dao.ExecuteProcedure((SqlOperation)sqlOperation);
        }


        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public override void Update(BaseEntity entity)
        {
            var cliente = (Cliente)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(cliente));
        }

        public override void Delete(BaseEntity entity)
        {
            var cliente = (Cliente)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(cliente));
        }
    }
}
