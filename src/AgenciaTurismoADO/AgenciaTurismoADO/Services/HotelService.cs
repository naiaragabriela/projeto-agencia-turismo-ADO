using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class HotelService
    {

        private readonly IHotelRepository _hotelRepository;

        public HotelService()
        {
            _hotelRepository = new HotelRepository();
        }

        public int Add(Hotel hotel)
        {
           return _hotelRepository.Add(hotel);

        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public int Update(Hotel hotel)
        {

        return _hotelRepository.Update(hotel);
        }

        public int Delete(Hotel hotel)
        {
            return _hotelRepository.Delete(hotel);
        }


    }
}

