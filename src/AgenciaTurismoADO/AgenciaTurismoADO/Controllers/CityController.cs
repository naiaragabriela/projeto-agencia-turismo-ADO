using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class CityController
    {
        public int Insert(City city)
        {
            return new CityService().InsertCity(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        public int Update(City city)
        {
            return new CityService().UpdateCity(city);
        }

        public int Delete(int id)
        {
            return new CityService().DeleteCity(id);
        }
    }
}
