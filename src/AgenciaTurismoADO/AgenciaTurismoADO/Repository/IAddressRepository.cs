using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public interface IAddressRepository
    {
        int Add(Address address);

        List<Address> GetAll();

        int Update(Address address);

        int Delete(Address address);

    }
}
