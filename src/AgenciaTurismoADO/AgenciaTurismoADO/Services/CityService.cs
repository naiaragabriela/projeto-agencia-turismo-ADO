using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class CityService
    {
        private readonly ICityRepository _repository;
        public CityService()
        {
            _repository = new CityRepository();
        }
        public int Add(City city)
        {
          return _repository.Add(city);
            
        }

        public List<City> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(City city)
        {
            return _repository.Update(city);
        }


        public int Delete(City city)
        {
            return _repository.Delete(city);
        }
    }
}
