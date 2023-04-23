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

        public int Add(Hotel hotel)
        {

            return new HotelService().Add(hotel);
        }

        public List<Hotel> GetAll()
        {
            return new HotelService().GetAll();
        }

        public int Update(Hotel hotel)

        {
            return new HotelService().Update(hotel);
        }

        public int Delete(Hotel hotel)
        {
            return new HotelService().Delete(hotel);
        }
    }
}
