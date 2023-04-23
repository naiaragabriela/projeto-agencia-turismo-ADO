using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    internal interface IClientRepository
    {
        int Add(Client client);

        List<Client> GetAll();

        int Update(Client client);

        int Delete(Client client);
    }
}
