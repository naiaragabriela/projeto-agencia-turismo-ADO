using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public int InsertClient(Client client)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Client (Name, Phone, DtRegistration, IdAddress) " +
                    "values (@Name, @Phone, @DtRegistration,@IdAddress); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", client.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress",client.Address.Id));

                status = (int)commandInsert.ExecuteScalar();
                client.Id = status;
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
        public List<Client> FindAll()
        {
            List<Client> clientList = new List<Client>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select client.Id AS IdClient, ");
            sb.Append("       client.Name AS NameClient, ");
            sb.Append("       client.Phone AS PhoneClient, ");
            sb.Append("       addressClient.Street As StreetClient, ");
            sb.Append("       address.Number AS NumberClient, ");
            sb.Append("       address.Neighborhood AS NeighborhoodClient,");
            sb.Append("       address.PostalCode AS PostalCodeClient, ");
            sb.Append("       address.Complement AS ComplementClient, ");
            sb.Append("       city.NameCity As NameCityClient, ");
            sb.Append("       FROM [ClIENT] client JOIN [ADDRESS] address ON client.[IdAddress] = address.[Id] ");
            sb.Append("       JOIN [CITY] ON city.Id = address.IdCity");
          


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new Client();

                client.Id = (int)dr["IdClient"];
                client.Name = (string)dr["NameClient"];
                client.Phone = (string)dr["PhoneClient"];
                client.Address = new Address()
                {
                    Street = (string)dr["StreetClient"],
                    Number = (int)dr["NumberClient"],
                    Neighborhood = (string)dr["NeighborhoodClient"],
                    PostalCode = (string)dr["PostalCodeClient"],
                    Complement = (string)dr["ComplementClient"],
                    City = new City()
                    {
                        NameCity = (string)dr["NameCityClient"]
                    }
                };
                clientList.Add(client);
            }
            return clientList;
        }


        public int Update(Client client)
        {
            string _update = "update Client set " +
                             "Name = @Name," +
                             "Phone = @Phone," +
                             "Address= IdAddress "+
                             " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Id", client.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandUpdate.Parameters.Add(new SqlParameter("@Phone", client.Phone));
            commandUpdate.Parameters.Add(new SqlParameter("@IdAddress", client.Address.Id));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(int id)
        {
            string _delete = "delete from Client where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}
