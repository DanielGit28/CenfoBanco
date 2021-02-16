using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public class DireccionManagement
    {
        private DireccionCrudFactory crudDireccion;

        public DireccionManagement()
        {
            crudDireccion = new DireccionCrudFactory();
        }

        public void Create(Direccion direccion)
        {

            crudDireccion.Create(direccion);

        }

        public int RetrieveIdentity()
        {
            return crudDireccion.getIdentity();
        }
        
        public List<Direccion> RetrieveAll()
        {
            return crudDireccion.RetrieveAll<Direccion>();
        }

        public Direccion RetrieveById(Direccion direccion)
        {
            return crudDireccion.Retrieve<Direccion>(direccion);
        }

        public void Update(Direccion direccion)
        {
            crudDireccion.Update(direccion);
        }

        public void Delete(Direccion direccion)
        {
            crudDireccion.Delete(direccion);
        }
    }
}
