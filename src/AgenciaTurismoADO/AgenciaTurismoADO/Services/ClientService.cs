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
        public List<Client> FindAll(string SELECT)
        {
            List<Client> clientList = new List<Client>();




            SqlCommand commandSelect = new SqlCommand(SELECT, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new Client();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Phone = (string)dr["Phone"];
                client.DtRegistration = (DateTime)dr["DTRegistration"];
                client.Address = new Address()
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
                        NameCity = (string)dr["NameCityt"],
                        DtRegistration = (DateTime)dr["DtRegistration"]
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
