using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class AddressController
    {

        public int Insert(Address address)
        {
            new CityController().Insert(address.City);

            return new AddressService().InsertAddress(address);
        }

        public List<Address> FindAll()
        {
            return new AddressService().FindAll();
        }
        public int Update(Address address)
        {
            new CityController().Update(address.City);

            return new AddressService().Update(address);
        }
        public int Delete(int id)
        {
            return new AddressService().Delete(id);
        }
    }
}
