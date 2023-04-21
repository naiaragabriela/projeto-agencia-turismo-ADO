using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public int InsertCity(City city)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into City (NameCity, DtRegistration) " +
                    "values (@NameCity, @DtRegistration); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@NameCity", city.NameCity));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", city.DtRegistration));


                status = (int)commandInsert.ExecuteScalar();
                city.Id = status;
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


        public List<City> FindAll()
        {
            List<City> cityList = new List<City>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select city.Id, ");
            sb.Append("       city.NameCity ");
            sb.Append("  FROM City c");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new City();

                city.Id = (int)dr["Id"];
                city.NameCity = (string)dr["NameCity"];

                cityList.Add(city);
            }
            return cityList;
        }

        public int UpdateCity(City city)
        {
            string _update = "update City set NameCity = @NameCity where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@NameCity", city.NameCity));
            commandUpdate.Parameters.Add(new SqlParameter("@Id", city.Id));

            return commandUpdate.ExecuteNonQuery();
        }


        public int DeleteCity(int id)
        {
            string _delete = "delete from City where Id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}
