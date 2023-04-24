using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int InsertHotel(Hotel hotel)
        {
            int status = 0;
            try

            {
                string strInsert = "insert into Hotel (NameHotel, IdAddress, CostHotel, DtRegistration) " +
                       "values (@NameHotel, @IdAddress, @CostHotel, @DtRegistration); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@NameHotel", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", hotel.Address.Id));
                commandInsert.Parameters.Add(new SqlParameter("@CostHotel", hotel.CostHotel));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", hotel.DtRegistration));

                status = (int)commandInsert.ExecuteScalar();
                hotel.Id = status;
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

        public List<Hotel> FindAll(string SELECT)
        {
            List<Hotel> hotelList = new List<Hotel>();


            SqlCommand commandSelect = new SqlCommand(SELECT, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new Hotel();

                hotel.Id = (int)dr["Id"];
                hotel.Name = (string)dr["Name"];
                hotel.DtRegistration = (DateTime)dr["DtRegistration"];
                hotel.CostHotel = (decimal)dr["CostHotel"];
                hotel.Address = new Address()
                {
                    Id = (int)dr["Id"],
                    Street = (string)dr["Street"],
                    Number = (int)dr["Number"],
                    Neighborhood = (string)dr["Neighborhood"],
                    PostalCode = (string)dr["PostalCode"],
                    Complement = (string)dr["Complement"],
                    City = new City()
                     {
                         Id = (int)dr["Id"],
                         NameCity = (string)dr["NameCity"],
                         DtRegistration = (DateTime)dr["DtRegistration"]
                      }
                };
               
                hotelList.Add(hotel);
            }
            return hotelList;
        }

        public int Update(Hotel hotel)
        {

            string _update = "UPDATE Hotel SET " +
                             "NameHotel = @NameHotel" +
                             "Address = @IdAdress" +
                             "CostHotel = @CostHotel" +
                             " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@NameHotel", hotel.Name));
            commandUpdate.Parameters.Add(new SqlParameter("@IdAddress", hotel.Address.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@CostHotel", hotel.CostHotel));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(int id)
        {
            string _delete = "delete from Hotel where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }


    }
}

