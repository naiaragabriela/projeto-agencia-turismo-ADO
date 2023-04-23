using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public int Add(Client client)
        {
          return _clientRepository.Add(client);
        }

        public List<Client> GetAll()
        {
          return _clientRepository.GetAll();
        }


        public int Update(Client client)
        {
          return _clientRepository.Update(client);
        }

        public int Delete(Client client)
        {
            return _clientRepository.Delete(client);
        }
    }
}
