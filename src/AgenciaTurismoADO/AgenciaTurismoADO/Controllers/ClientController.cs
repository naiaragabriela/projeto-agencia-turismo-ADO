using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class ClientController
    {

        public int Add(Client client)
        {


            return new ClientService().Add(client);
        }

        public List<Client> GetAll()
        {
            return new ClientService().GetAll();
        }


        public int Update(Client client)
        {

            return new ClientService().Update(client);
        }
        public int Delete(Client client)
        {
            return new ClientService().Delete(client);
        }
    }
}
