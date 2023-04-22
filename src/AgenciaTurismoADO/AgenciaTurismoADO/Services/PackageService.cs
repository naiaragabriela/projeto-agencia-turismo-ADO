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

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }


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

            sb.Append("select package.Id AS IdPackage ");
            sb.Append("       package.Cost AS PackageCost, ");
            sb.Append("       package.DtRegistration AS PackageRegistration, ");
            sb.Append("       client.Id AS IdClient, ");
            sb.Append("       client.Name AS NameClient, ");
            sb.Append("       client.Phone AS PhoneClient, ");
            sb.Append("       client.DtRegistration AS ClientRegistration , ");
            sb.Append("       addressClient.Id AS IdAddress, ");
            sb.Append("       addressClient.Street As StreetClient, ");
            sb.Append("       addressClient.Number AS NumberClient, ");
            sb.Append("       addressClient.Neighborhood AS NeighborhoodClient,");
            sb.Append("       addressClient.PostalCode AS PostalCodeClient, ");
            sb.Append("       addressClient.Complement AS ComplementClient, ");
            sb.Append("       addressClient.DtRegistration AS AddressRegistration , ");
            sb.Append("       cityClient.Id AS IdCity, ");
            sb.Append("       cityClient.NameCity As NameCityClient, ");
            sb.Append("       cityClient.DtRegistration As RegistrationCityClient, ");
            sb.Append("       FROM [PACKAGE] package JOIN [CLIENT] client ON package.[IdClient] = client.[Id] ");
            sb.Append("       FROM [ClIENT] client JOIN [ADDRESS] addressClient ON client.[IdAddress] = addressClient.[Id] ");
            sb.Append("       JOIN [CITY] city ON city.[Id] = addressClient.[IdCity]");
            sb.Append("       hotel.Id AS IdHotel, ");
            sb.Append("       hotel.Name AS NameHotel , ");
            sb.Append("       hotel.DtRegistration AS HotelRegistration , ");
            sb.Append("       hotel.CostHotel As CostHotel, ");
            sb.Append("       addressHotel.Id AS IdAddressHotel, ");
            sb.Append("       addressHotel.Street AS StreetHotel, ");
            sb.Append("       addressHotel.Number AS NumberHotel, ");
            sb.Append("       addressHotel.Neighborhood AS NeighborhoodHotel, ");
            sb.Append("       addressHotel.PostalCode As PostalCodeHotel, ");
            sb.Append("       addressHotel.Complement AS ComplementHotel, ");
            sb.Append("       addressHotel.DtRegistration AS RegistrationHotel, ");
            sb.Append("       cityHotel.Id AS IdCityHotel, ");
            sb.Append("       cityHotel.NameCity AS NameCityHotel, ");
            sb.Append("       cityHotel.DtRegistration AS CityRegistration, ");
            sb.Append("       FROM [PACKAGE] package JOIN [HOTEL] hotel ON package.[IdHotel] = hotel.[Id] ");
            sb.Append("       FROM [HOTEL] hotel JOIN [ADDRESS] addressHotel ON hotel.[IdAddressHotel] = addressHotel.[Id] ");
            sb.Append("       JOIN [CITY] cityHotel ON cityHotel.[Id] = addressHotel.[IdCityHotel]");
            sb.Append("       ticket.Id AS IdTicket, ");
            sb.Append("       ticket.DtRegistration AS TicketResgistration,");
            sb.Append("       ticket.CostTicket AS CostTicket, ");
            sb.Append("       addressOrigin.Id AS IdOrigin, ");
            sb.Append("       addressOrigin.Street AS OriginStreet, ");
            sb.Append("       addressOrigin.Number AS OriginNumber, ");
            sb.Append("       addressOrigin.Neighborhood AS OriginNeighborhood, ");
            sb.Append("       addressOrigin.PostalCode AS OriginPostalCode, ");
            sb.Append("       addressOrigin.Complement AS OriginComplemnt, ");
            sb.Append("       addressOrigin.DtRegistration AS OriginResgistration,");
            sb.Append("       cityOrigin.Id AS IdCityOrigin, ");
            sb.Append("       cityOrigin.NameCity AS NameCityOrigin, ");
            sb.Append("       cityOrigin.DtRegistration AS CityOriginResgistration,");
            sb.Append("       addressDestination.Id AS IdDestination, ");
            sb.Append("       addressDestination.Street AS DestinationStreet, ");
            sb.Append("       addressDestination.Number AS DestinationNumber, ");
            sb.Append("       addressDestination.Neighborhood AS DestinationNeighborhood, ");
            sb.Append("       addressDestination.PostalCode As DestinationPostalCode, ");
            sb.Append("       addressDestination.Complement AS DestinationComplement, ");
            sb.Append("       addressDestination.DtRegistration AS DestinationResgistration,");
            sb.Append("       cityDestination.Id AS IdCityDestination, ");
            sb.Append("       cityDestination.NameCity AS NameCityDestination, ");
            sb.Append("       cityDestination.Registration AS CityDestinationRegistration, ");
            sb.Append("       FROM [PACKAGE] package JOIN [TICKET] ticket ON package.[IdTicket] = ticket.[Id] ");
            sb.Append("       FROM [TICKET] client JOIN [ADDRESS] addressOrigin ON ticket.[IdOrigin] = addressOrigin.[Id] ");
            sb.Append("       JOIN [CITY] cityOrigin ON cityOrigin.[Id] = addressOrigin.[IdCityOrigin]");
            sb.Append("       JOIN [ADDRESS] addressDestination ON ticket.[IdDestination] = address.IdCity");
            sb.Append("       JOIN [CITY] cityDestination ON city.Id = address.IdCity");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package package = new Package();

                package.Id = (int)dr["IdPackage"];
                package.Cost = (decimal)dr["PackageCost"];
                package.DtRegistration = (DateTime)dr["PackageRegistration"];
                package.Client = new Client()
                {  
                    Id = (int)dr["IdClient"],
                    Name = (string)dr["NameClient"],
                    Phone = (string)dr["PhoneClient"],
                    DtRegistration = (DateTime)dr["ClientRegistration"],
                    Address = new Address()
                    {
                        Id = (int)dr["IdAddress"],
                        Street = (string)dr["StreetClient"],
                        Number = (int)dr["NumberClient"],
                        Neighborhood = (string)dr["NeighborhoodClient"],
                        PostalCode = (string)dr["PostalCodeClient"],
                        Complement = (string)dr["ComplementClient"],
                        DtRegistration = (DateTime)dr["AddressRegistration"],
                        City = new City()
                        {
                            Id = (int)dr["IdCity"],
                            NameCity = (string)dr["NameCityClient"],
                            DtRegistration = (DateTime)dr["RegistrationCityClient"]
                        }
                    }
                };
                package.Hotel = new Hotel()
                {
                    Id = (int)dr["IdHotel"],
                    Name = (string)dr["NameHotel"],
                    CostHotel = (decimal)dr["CostHotel"],
                    DtRegistration = (DateTime)dr["ClientRegistration"],
                    Address = new Address()
                    {
                        Id = (int)dr["IdAddressHotel"],
                        Street = (string)dr["StreetHotel"],
                        Number = (int)dr["NumberHotel"],
                        Neighborhood = (string)dr["NeighborhoodHotel"],
                        PostalCode = (string)dr["PostalCodeHotel"],
                        Complement = (string)dr["ComplementHotel"],
                        DtRegistration = (DateTime)dr["RegistrationHotel"],
                        City = new City()
                        {
                            Id = (int)dr["IdCityHotel"],
                            NameCity = (string)dr["NameCityHotel"],
                            DtRegistration = (DateTime)dr["CityRegistration"],
                        }
                    }
                };
                package.Ticket = new Ticket()
                {
                    Id = (int)dr["IdTicket"],
                    DtRegistration = (DateTime)dr["TicketResgistration"],
                    CostTicket = (decimal)dr["CostTicket"],
                    Origin = new Address()
                    {
                        Id = (int)dr["IdOrigin"],
                        Street = (string)dr["OriginStreet"],
                        Number = (int)dr["OriginNumber"],
                        Neighborhood = (string)dr["OriginNeighborhood"],
                        PostalCode = (string)dr["OriginPostalCode"],
                        Complement = (string)dr["OriginComplemnt"],
                        DtRegistration = (DateTime)dr["OriginResgistration"],
                        City = new City()
                        {
                            Id = (int)dr["IdCityOrigin"],
                            NameCity = (string)dr["NameCityOrigin"],
                            DtRegistration = (DateTime)dr["CityOriginResgistration"],
                        }
                    },
                    Destination = new Address()
                    {
                        Id = (int)dr["IdDestination"],
                        Street = (string)dr["DestinationStreet"],
                        Number = (int)dr["DestinationNumber"],
                        Neighborhood = (string)dr["DestinationNeighborhood"],
                        PostalCode = (string)dr["DestinationPostalCode"],
                        Complement = (string)dr["DestinationComplement"],
                        DtRegistration = (DateTime)dr["DestinationResgistration"],
                        City = new City()
                        {
                            Id = (int)dr["IdCityDestination"],
                            NameCity = (string)dr["NameCityDestination"],
                            DtRegistration = (DateTime)dr["CityDestinationRegistration"],
                        }
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
