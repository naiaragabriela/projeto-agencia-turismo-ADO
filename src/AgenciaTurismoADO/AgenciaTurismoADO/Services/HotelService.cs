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

        public List<Hotel> FindAll()
        {
            List<Hotel> hotelList = new List<Hotel>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select hotel.Id AS IdHotel, ");
            sb.Append("       hotel.Name AS NameHotel , ");
            sb.Append("       hotel.DtRegistration AS HotelRegistration , ");
            sb.Append("       hotel.CostHotel As CostHotel, ");
            sb.Append("       addressHotel.Id AS IdAddress, ");
            sb.Append("       addressHotel.Street AS StreetHotel, ");
            sb.Append("       addressHotel.Number AS NumberHotel, ");
            sb.Append("       addressHotel.Neighborhood AS NeighborhoodHotel, ");
            sb.Append("       addressHotel.PostalCode As PostalCodeHotel, ");
            sb.Append("       addressHotel.Complement AS ComplementHotel, ");
            sb.Append("       cityHotel.Id AS IdCity, ");
            sb.Append("       cityHotel.NameCity AS NameCityHotel, ");
            sb.Append("       cityHotel.DtRegistration AS CityRegistration, ");
            sb.Append("       FROM [HOTEL] hotel JOIN [ADDRESS] addressHotel ON hotel.[IdAddress] = addressHotel.[Id] ");
            sb.Append("       JOIN [CITY] cityHotel ON cityHotel.[Id] = addressHotel.[IdCity]");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new Hotel();

                hotel.Id = (int)dr["IdHotel"];
                hotel.Name = (string)dr["NameHotel"];
                hotel.DtRegistration = (DateTime)dr["HotelRegistration"];
                hotel.CostHotel = (decimal)dr["CostHotel"];
                hotel.Address = new Address()
                {
                    Id = (int)dr["IdAddress"],
                    Street = (string)dr["StreetHotel"],
                    Number = (int)dr["NumberHotel"],
                    Neighborhood = (string)dr["NeighborhoodHotel"],
                    PostalCode = (string)dr["PostalCodeHotel"],
                    Complement = (string)dr["ComplementHotel"],
                    City = new City()
                     {
                         Id = (int)dr["IdCity"],
                         NameCity = (string)dr["NameCityHotel"],
                         DtRegistration = (DateTime)dr["CityRegistration"]
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

