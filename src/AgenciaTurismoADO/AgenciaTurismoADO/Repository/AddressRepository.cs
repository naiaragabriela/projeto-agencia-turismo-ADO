using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
                result = (int)db.ExecuteScalar(Address.INSERT, new
                {
                    Street = address.Street,
                    Number = address.Number,
                    Neighborhood = address.Neighborhood,
                    PostalCode = address.PostalCode,
                    Complement = address.Complement,
                    DtRegistration = address.DtRegistration,
                    IdCity = address.City.Id
                });
            }
            return result;
        }

        public List<Address> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();

                var address = db.Query<Address, City, Address>(Address.SELECT,(address, city) => 
                { 
                    address.City = city;
                    return address; 
                },splitOn: "SplitIdCity");



                return (List<Address>)address;
            }


        }

        public int Update(Address address)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Address.UPDATE, new
                {
                    Street = address.Street,
                    Number = address.Number,
                    Neighborhood = address.Neighborhood,
                    PostalCode = address.PostalCode,
                    Complement = address.Complement,
                    DtRegistration = address.DtRegistration,
                    IdCity = address.City.Id
                });
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
