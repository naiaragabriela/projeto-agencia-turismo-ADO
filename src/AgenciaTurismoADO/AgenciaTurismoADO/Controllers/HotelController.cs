using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class HotelController
    {

        public int Insert(Hotel hotel)
        {
            new AddressController().Insert(hotel.Address);

            return new HotelService().InsertHotel(hotel);
        }

        public List<Hotel> FindAll()
        {
            return new HotelService().FindAll();
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
