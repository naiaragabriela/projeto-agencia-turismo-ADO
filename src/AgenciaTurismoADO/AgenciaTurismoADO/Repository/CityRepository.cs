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
    public class CityRepository : ICityRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
  
        public int Add(City city)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(City.INSERT, city);
            }
            return result;
        }

        public List<City> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var city = db.Query<City>(City.SELECT);
                return (List<City>)city;
            }
        }


        public int Update (City city)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(City.UPDATE, city);
            }
            return result;

        }

        public int Delete(City city)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(City.DELETE, city);
            }
            return result;

        }
    }
}
