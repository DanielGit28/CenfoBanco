using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public class CuentaManagement
    {
        private CuentaCrudFactory crudCuenta;

        public CuentaManagement()
        {
            crudCuenta = new CuentaCrudFactory();
        }

        public void Create(Cuenta cuenta)
        {

            crudCuenta.Create(cuenta);

        }


        public List<Cuenta> RetrieveAll()
        {
            return crudCuenta.RetrieveAll<Cuenta>();
        }

        public Cuenta RetrieveById(Cuenta cuenta)
        {
            return crudCuenta.Retrieve<Cuenta>(cuenta);
        }

        public void Update(Cuenta cuenta)
        {
            crudCuenta.Update(cuenta);
        }

        public void Delete(Cuenta cuenta)
        {
            crudCuenta.Delete(cuenta);
        }
    }
}
