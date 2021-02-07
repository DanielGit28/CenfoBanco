﻿using System.Collections.Generic;
using AccesoDatos.DAO;
using Entidades;

namespace AccesoDatos.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract void Create(BaseEntity entity);
        public abstract T Retrieve<T>(BaseEntity entity);
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseEntity entity);
        public abstract void Delete(BaseEntity entity);
    }
}
