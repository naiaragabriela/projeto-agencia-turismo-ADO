using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
