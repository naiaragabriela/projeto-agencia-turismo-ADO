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
