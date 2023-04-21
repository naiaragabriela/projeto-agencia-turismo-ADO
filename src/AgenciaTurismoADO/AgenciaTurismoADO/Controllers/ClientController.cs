using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class ClientController
    {

        public int Insert(Client client)
        {
            new AddressController().Insert(client.Address);

            return new ClientService().InsertClient(client);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }


        public int Update(Client client)
        {
            new AddressController().Update(client.Address);

            return new ClientService().Update(client);
        }
        public int Delete(int id)
        {
            return new ClientService().Delete(id);
        }
    }
}
