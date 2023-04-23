using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public interface IHotelRepository
    {
       
        int Add(Hotel hotel);

        List<Hotel> GetAll();

        int Update(Hotel hotel);

        int Delete(Hotel hotel);
    }
}
