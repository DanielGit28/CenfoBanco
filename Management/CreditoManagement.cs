using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public class CreditoManagement
    {
        private CreditoCrudFactory crudCredito;

        public CreditoManagement()
        {
            crudCredito = new CreditoCrudFactory();
        }

        public void Create(Credito credito)
        {

            crudCredito.Create(credito);

        }


        public List<Credito> RetrieveAll()
        {
            return crudCredito.RetrieveAll<Credito>();
        }

        public Credito RetrieveById(Credito credito)
        {
            return crudCredito.Retrieve<Credito>(credito);
        }

        public void Update(Credito credito)
        {
            crudCredito.Update(credito);
        }

        public void Delete(Credito credito)
        {
            crudCredito.Delete(credito);
        }
    }
}
