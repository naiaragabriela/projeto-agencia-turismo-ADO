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

        public int Add(Address address)
        {
            return new AddressService().Add(address);
        }

        public List<Address> GetAll()
        {
            return new AddressService().GetAll();
        }
        public int Update(Address address)
        {

            return new AddressService().Update(address);
        }
        public int Delete(Address address)
        {
            return new AddressService().Delete(address);
        }
    }
}
