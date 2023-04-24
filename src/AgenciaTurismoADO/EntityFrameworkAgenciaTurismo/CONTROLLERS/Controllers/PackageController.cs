using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class PackageController
    {
        public int Add(Package package)
        {
          

            return new PackageService().Add(package);
        }

        public List<Package> GetAll()
        {
            return new PackageService().GetAll();
        }

        public int Update(Package package)
        {
            return new PackageService().Update(package);
        }

        public int Delete(Package package)
        {
            return new PackageService().Delete(package);
        }


    }
}
