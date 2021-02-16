using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public class ClienteManagement
    {
        private ClienteCrudFactory crudCliente;

        public ClienteManagement()
        {
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Cliente cliente)
        {

            crudCliente.Create(cliente);

        }


        public List<Cliente> RetrieveAll()
        {
            return crudCliente.RetrieveAll<Cliente>();
        }

        public Cliente RetrieveById(Cliente cliente)
        {
            return crudCliente.Retrieve<Cliente>(cliente);
        }

        public void Update(Cliente cliente)
        {
            crudCliente.Update(cliente);
        }

        public void Delete(Cliente cliente)
        {
            crudCliente.Delete(cliente);
        }
    }
}
