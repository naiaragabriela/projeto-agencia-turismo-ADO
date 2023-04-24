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

        public List<Package> FindAll(string SELECT)
        {
            List<Package> packageList = new List<Package>();

            SqlCommand commandSelect = new SqlCommand(SELECT, conn);
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
