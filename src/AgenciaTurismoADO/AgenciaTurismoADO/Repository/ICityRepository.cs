using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public interface ICityRepository
    {
        int Add(City city);

        List<City> GetAll();

        int Update(City city);

        int Delete(City city);
    }
}
