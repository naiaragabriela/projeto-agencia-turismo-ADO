using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;


        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int InsertAddress(Address address)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Address(Street, Number, Neighborhood, PostalCode, Complement, DtRegistration,IdCity) " +
                    "values (@Street, @Number, @Neighborhood, @PostalCode, @Complement, @DtRegistration,@IdCity); " +
                    "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", address.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", address.City.Id));


                status = (int)commandInsert.ExecuteScalar();
                address.Id = status;

            }
            catch (Exception)
            {
                status = 0;
                throw;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public List<Address> FindAll(string SELECT)
        {
            List<Address> addressList = new List<Address>();

            SqlCommand commandSelect = new SqlCommand(SELECT, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Address address = new Address();

                address.Id = (int)dr["Id"];
                address.DtRegistration = (DateTime)dr["DtRegistration"];
                address.Street = (string)dr["Street"];
                address.Number = (int)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.PostalCode = (string)dr["PostalCode"];
                address.Complement = (string)dr["Complement"];
                address.City = new City()
                {
                    Id = (int)dr["IdCity"],
                    NameCity = (string)dr["NameCity"],
                    DtRegistration = (DateTime)dr["CityRegistration"]
                };

                addressList.Add(address);
            }
            return addressList;
        }


        public int Update(Address address)

        {
            string _update = "update Address set " +
                 "Street = @Street, " +
                 "Number = @Number, " +
                 "Neighborhood = @Neighborhood, " +
                 "PostalCode = @PostalCode, " +
                 "Complement = @Complement, " +
                 "City = @IdCity "+
                 "where id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Id", address.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Street", address.Street));
            commandUpdate.Parameters.Add(new SqlParameter("@Number", address.Number));
            commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            commandUpdate.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commandUpdate.Parameters.Add(new SqlParameter("@Complement", address.Complement));
            commandUpdate.Parameters.Add(new SqlParameter("@IdCity", address.City.Id));



            return commandUpdate.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            string _delete = "delete from Address where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id",id));

            return (int)commandDelete.ExecuteNonQuery();
        }


    }
}
