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
    public class AddressRepository: IAddressRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Address address)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Address.INSERT, address);
            }
            return result;
        }

        public List<Address> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var address = db.Query<Address>(Address.SELECT);
                return (List<Address>)address;
            }


        }

        public int Update(Address address)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Address.UPDATE, address);
            }
            return result;
        }

        public int Delete(Address address)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Address.DELETE, address);
            }
            return result;


        }
    }
}
