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
        public int Add(City city)
        {
            return new CityService().Add(city);
        }

        public List<City> GetAll()
        {
            return new CityService().GetAll();
        }

        public int Update(City city)
        {
            return new CityService().Update(city);
        }

        public int Delete(City city)
        {
            return new CityService().Delete(city);
        }
    }
}
