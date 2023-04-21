using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;


        public int InsertPackage(Package package)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Package (IdHotel, IdTicket, DtRegistration, Cost, IdClient)" +
                    "values (@IdHotel, @IdTicket, @DtRegistration, @Cost, @IdClient)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", package.Hotel.Id));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", package.Ticket.Id));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", package.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@Cost", package.Cost));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", package.Client.Id));

                status = (int)commandInsert.ExecuteNonQuery();
                package.Id = status;
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

        public List<Package> FindAll()
        {
            List<Package> packageList = new List<Package>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select package.Id, ");
            sb.Append("       package.Cost, ");
            sb.Append("       package.DtRegistration, ");
            sb.Append("       client.Id, ");
            sb.Append("       client.Name, ");
            sb.Append("       client.Phone, ");
            sb.Append("       client.Address, ");
            sb.Append("       hotel.Id, ");
            sb.Append("       hotel.NameHotel, ");
            sb.Append("       hotel.CostHotel, ");
            sb.Append("       hotel.Address, ");
            sb.Append("       ticket.Id, ");
            sb.Append("       ticket.CostTicket");
            sb.Append("       ticket.Origin");
            sb.Append("       ticket.Destination");
            sb.Append("       address.Street, ");
            sb.Append("       address.Number, ");
            sb.Append("       address.Neighborhood, ");
            sb.Append("       address.PostalCode, ");
            sb.Append("       address.Complement, ");
            sb.Append("       city.NameCity, ");
            sb.Append("       FROM [PACKAGE] package JOIN [CLIENT] client ON package.[IdClient] = client.[Id] ");
            sb.Append("       FROM [PACKAGE] package JOIN [HOTEL] hotel ON package.[IdHotel] = hotel.[Id] ");
            sb.Append("       FROM [PACKAGE] package JOIN [TICKET] ticket ON package.[IdTicket] = ticket.[Id] ");
  

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package package = new Package();

                package.Id = (int)dr["Id"];
                package.DtRegistration = (DateTime)dr["DtRegsitration"];
                package.Cost = (decimal)dr["Cost"];
                package.Client = new Client()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Phone = (string)dr["Phone"],
                    Address = new Address()
                    {
                        Street = (string)dr["Street"],
                        Number = (int)dr["Number"],
                        Neighborhood = (string)dr["Neighborhood"],
                        PostalCode = (string)dr["PostalCode"],
                        Complement = (string)dr["Complement"],
                        City = new City()
                        {
                            NameCity = (string)dr["NameCity"]
                        }
                    }
                };
                package.Hotel = new Hotel()
                {
                    Id = (int)dr["Id"],
                    NameHotel = (string)dr["Name"],
                    CostHotel = (decimal)dr["CostHotel"],
                    Address = new Address()
                    {
                        Street = (string)dr["Street"],
                        Number = (int)dr["Number"],
                        Neighborhood = (string)dr["Neighborhood"],
                        PostalCode = (string)dr["PostalCode"],
                        Complement = (string)dr["Complement"],
                        City = new City()
                        {
                            Id = (int)dr["Id"],
                            NameCity = (string)dr["NameCity"]
                        }
                    }
                };
                package.Ticket = new Ticket()
                {
                    Id = (int)dr["Id"],
                    CostTicket = (decimal)dr["CostTiket"],
                    Origin = new Address()
                    {
                        Street = (string)dr["Street"],
                        Number = (int)dr["Number"],
                        Neighborhood = (string)dr["Neighborhood"],
                        PostalCode = (string)dr["PostalCode"],
                        Complement = (string)dr["Complement"]
                    },
                    Destination = new Address()
                    {
                        Street = (string)dr["Street"],
                        Number = (int)dr["Number"],
                        Neighborhood = (string)dr["Neighborhood"],
                        PostalCode = (string)dr["PostalCode"],
                        Complement = (string)dr["Complement"]
                    }
                };

            packageList.Add(package);
            };

            return packageList;
        }

            public int Update(Package package)
            {

                string _update = "update Package set " +
                     "Hotel = @IdHotel" +
                     "Ticket = @IdTicket" +
                     "Client = @IdClient" +
                     "Cost = @Cost" +
                     " where Id = @id";

                SqlCommand commandUpdate = new SqlCommand(_update, conn);   

                    commandUpdate.Parameters.Add(new SqlParameter("@IdHotel", package.Hotel));
                    commandUpdate.Parameters.Add(new SqlParameter("@IdTicket", package.Ticket));
                    commandUpdate.Parameters.Add(new SqlParameter("@IdClient", package.Client));
                    commandUpdate.Parameters.Add(new SqlParameter("@Cost", package.Cost));

                return commandUpdate.ExecuteNonQuery();
            }

                public int Delete(int id)
                {
                    string _delete = "delete from Package where id =@id";
                    SqlCommand commandDelete = new SqlCommand(_delete, conn);
                    commandDelete.Parameters.Add(new SqlParameter("@id", id));

                    return (int)commandDelete.ExecuteNonQuery();
                }


    }
}
