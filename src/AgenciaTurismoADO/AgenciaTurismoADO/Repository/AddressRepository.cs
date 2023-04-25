using System.Data.SqlClient;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class AddressRepository : IAddressRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Address address)
        {
            int result = 0;

            using (SqlConnection db = new(strConn))
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
            using (SqlConnection db = new(strConn))
            {
                db.Open();

                IEnumerable<Address> address = db.Query<Address, City, Address>(Address.SELECT, (address, city) =>
                {
                    address.City = city;
                    return address;
                }, splitOn: "SplitIdCity");



                return (List<Address>)address;
            }


        }

        public int Update(Address address)
        {
            int result = 0;

            using (SqlConnection db = new(strConn))
            {
                db.Open();
                result = db.Execute(Address.UPDATE, new
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

            using (SqlConnection db = new(strConn))
            {
                db.Open();
                result = db.Execute(Address.DELETE, address);
            }
            return result;


        }
    }
}
