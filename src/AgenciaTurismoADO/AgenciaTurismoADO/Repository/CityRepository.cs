using System.Data.SqlClient;
using AgenciaTurismoADO.Context;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class CityRepository : ICityRepository
    {
        public int Add(City city)
        {
            using (var context = new AgencyTourismContext())
            {
                
                context.Cities.Add(city);
                context.SaveChanges();
            }
            return city.Id;
        }

        public List<City> GetAll()
        {
            using (var context = new AgencyTourismContext())
            {
                return context.Cities.ToList();
            }
        }

        public int Update(City city)
        {
            using (var context = new AgencyTourismContext())
            {
                context.Cities.Update(city);
                context.SaveChanges();
            }
            return city.Id;

        }

        public int Delete(City city)
        {
            using (var context = new AgencyTourismContext())
            {
                context.Cities.Remove(city);
                context.SaveChanges();
            }
            return city.Id;

        }
    }
}
