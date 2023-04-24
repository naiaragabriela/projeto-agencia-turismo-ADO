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
        public int Insert(Package package)
        {
         
            return new PackageService().InsertPackage(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public int Update(Package package)
        {
        

            return new PackageService().Update(package);
        }

        public int Delete(int id)
        {
            return new PackageService().Delete(id);
        }


    }
}
