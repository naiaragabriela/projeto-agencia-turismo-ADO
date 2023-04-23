using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public class PackageRepository : IPackageRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Package package)
        {
            throw new NotImplementedException();
        }

        public List<Package> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Package package)
        {
            throw new NotImplementedException();
        }
        public int Delete(Package package)
        {
            throw new NotImplementedException();
        }

    }
}
