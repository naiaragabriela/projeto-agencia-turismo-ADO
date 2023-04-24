using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class HotelController
    {
        public readonly static string SELECT = @"SELECT[Hotel].[Id] AS Id, [Name], [CostHotel],[Hotel].[DtRegistration],
            [AddressHotel].[Id] AS Id, [Street],[Number],[Neighborhood],[PostalCode],[Complement],[AddressHotel].[DtRegistration],
            [AddressCity].[Id] AS Id, [AddressCity].[NameCity], [AddressCity].[DtRegistration]
            FROM[Hotel] JOIN[Address] AddressHotel ON IdAddress = AddressHotel.Id
            JOIN[City] AddressCity ON AddressHotel.IdCity= AddressCity.Id";
        public int Insert(Hotel hotel)
        {
       

            return new HotelService().InsertHotel(hotel);
        }

        public List<Hotel> FindAll(string SELECT)
        {
            return new HotelService().FindAll(SELECT);
        }

        public int Update(Hotel hotel)

        {
            
            return new HotelService().Update(hotel);
        }

        public int Delete(int id)
        {
            return new HotelService().Delete(id);
        }
    }
}
