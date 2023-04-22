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
        SqlConnection conn;
        ConnectionDB connectionDB;

        public PackageService()
        {
            connectionDB = new ConnectionDB();
            conn = connectionDB.OpenConnectionDB();
        }


        public int InsertPackage(Package package)
        {

            int status = 0;
            try
            {
                conn.Open();

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

            sb.Append("select package.Id AS IdPackage ");
            sb.Append("       package.Cost AS PackageCost, ");
            sb.Append("       package.DtRegistration AS PackageRegistration, ");
            sb.Append("       client.Id AS IdClient, ");
            sb.Append("       client.Name AS NameClient, ");
            sb.Append("       client.Phone AS PhoneClient, ");
            sb.Append("       client.Address AS AddressClient, ");
            sb.Append("       address.Street AS ClientStreet ");
            sb.Append("       address.Number AS ClientNumber, ");
            sb.Append("       address.Neighborhood As ClientNeighborhood, ");
            sb.Append("       address.PostalCode AS ClientPostalCode, ");
            sb.Append("       address.Complement AS ClientComplement, ");
            sb.Append("       city.NameCity AS ClientNameCity, ");
            sb.Append("       hotel.Id AS IdHotel, ");
            sb.Append("       hotel.Name AS NameHotel, ");
            sb.Append("       hotel.CostHotel AS CostHotel, ");
            sb.Append("       hotel.Address AS AddressHotel, ");
            sb.Append("       address.Street AS HotelStreet, ");
            sb.Append("       address.Number AS HotelNumber, ");
            sb.Append("       address.Neighborhood AS HotelNeighborhood, ");
            sb.Append("       address.PostalCode AS HotelPostalCode, ");
            sb.Append("       address.Complement AS HotelComplement, ");
            sb.Append("       city.NameCity AS HotelNameCity, ");
            sb.Append("       ticket.Id AS IdTicket, ");
            sb.Append("       ticket.CostTicket AS CostTicket");
            sb.Append("       ticket.Origin AS OriginTicket");
            sb.Append("       address.Street AS OriginStreet, ");
            sb.Append("       address.Number AS OriginNumber, ");
            sb.Append("       address.Neighborhood AS OriginNeighborhood, ");
            sb.Append("       address.PostalCode AS OriginPostalCode, ");
            sb.Append("       address.Complement AS OriginComplement, ");
            sb.Append("       city.NameCity AS OriginNameCity, ");
            sb.Append("       ticket.Destination AS DestinationTicket");
            sb.Append("       address.Street As DestinationStreet, ");
            sb.Append("       address.Number AS DestinationNumber, ");
            sb.Append("       address.Neighborhood As DestinationNeighborhood, ");
            sb.Append("       address.PostalCode AS DestinationPostalCode, ");
            sb.Append("       address.Complement AS Complement, ");
            sb.Append("       city.NameCity AS NameCity, ");
            sb.Append("       FROM [PACKAGE] package JOIN [CLIENT] client ON package.[IdClient] = client.[Id] ");
            sb.Append("       JOIN [ADDRESS] addressClient ON ");
            sb.Append("       FROM [PACKAGE] package JOIN [HOTEL] hotel ON package.[IdHotel] = hotel.[Id] ");
            sb.Append("       JOIN [ADDRESS] addressClient ON ");
            sb.Append("       FROM [PACKAGE] package JOIN [TICKET] ticket ON package.[IdTicket] = ticket.[Id] ");
            sb.Append("       JOIN [ADDRESS] addressClient ON ");

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

                    commandUpdate.Parameters.Add(new SqlParameter("@IdHotel", package.Hotel.Id));
                    commandUpdate.Parameters.Add(new SqlParameter("@IdTicket", package.Ticket.Id));
                    commandUpdate.Parameters.Add(new SqlParameter("@IdClient", package.Client.Id));
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
