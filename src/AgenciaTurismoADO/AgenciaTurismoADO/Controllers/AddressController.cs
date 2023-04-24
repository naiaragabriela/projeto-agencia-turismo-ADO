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

        public readonly static string SELECT = "SELECT[Address].[Id] AS Id, [Street],[Number],[Neighborhood],[PostalCode],[Complement],[Address].[DtRegistration]," +
                                               "[addressCity].[Id] AS SplitIdCity,[addressCity].[Id], [addressCity].[NameCity], [addressCity].[DtRegistration]" +
                                                "FROM[Address] JOIN[City] addressCity ON address.IdCity = addressCity.Id";

        public readonly AddressService _addressService;
        public AddressController()
        {
            _addressService = new AddressService();
        }

        public int Insert(Address address)
        {
            
            return _addressService.InsertAddress(address);
        }

        public List<Address> FindAll()
        {
            return _addressService.FindAll(SELECT);
        }

        public int Update(Address address)
        {
            return new AddressService().Update(address);
        }

        public int Delete(int id)
        {
            return new AddressService().Delete(id);
        }
    }
}
