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

        public readonly static string SELECT = "SELECT[Client].[Id] AS Id, [Name], [Phone],[Client].[DtRegistration]," +
          "[AddressClient].[Id] AS Id, [Street],[Number],[Neighborhood],[PostalCode],[Complement],[AddressClient].[DtRegistration]," +
          "[AddressCity].[Id] AS Id, [AddressCity].[NameCity], [AddressCity].[DtRegistration] " +
           "FROM[Client] JOIN[Address] AddressClient ON IdAddress = AddressClient.Id " +
           "JOIN[City] AddressCity ON AddressClient.IdCity= AddressCity.Id";

        public int Insert(Client client)
        {
           

            return new ClientService().InsertClient(client);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll(SELECT);
        }


        public int Update(Client client)
        {
            

            return new ClientService().Update(client);
        }
        public int Delete(int id)
        {
            return new ClientService().Delete(id);
        }
    }
}
