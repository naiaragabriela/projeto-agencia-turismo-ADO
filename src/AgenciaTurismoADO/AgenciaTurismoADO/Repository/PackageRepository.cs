using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class PackageRepository : IPackageRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Package package)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Package.INSERT, package);
            }
            return result;
        }

        public List<Package> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var package = db.Query<Package>(Package.SELECT);
                return (List<Package>)package;
            }
        }

        public int Update(Package package)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Package.UPDATE, package);
            }
            return result;
        }

        public int Delete(Package package)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Package.DELETE, package);
            }
            return result;
        }

    }
}
