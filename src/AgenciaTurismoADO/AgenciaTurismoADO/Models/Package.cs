using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Package
    {
        #region Constant
        public readonly static string INSERT = "INSERT INTO Package (IdHotel, IdTicket, DtRegistration, Cost, IdClient)" +
                    "VALUES (@IdHotel, @IdTicket, @DtRegistration, @Cost, @IdClient); select cast(scope_identity() as int)";




        /*

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

        */


        public readonly static string SELECT = " ";

        public readonly static string UPDATE = "UPDATE Package SET " +
                                               "Hotel = @IdHotel" +
                                               "Ticket = @IdTicket" +
                                               "Client = @IdClient" +
                                               "Cost = @Cost" +
                                                 "WHERE Id = @id";

        public readonly static string DELETE = "DELETE FROM PACKAGE WHERE Id = @Id";

        #endregion

        #region Properties
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DtRegistration { get; set; }
        public decimal Cost { get; set; }
        public Client Client { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id do Pacote: "+ Id+
                   "\nCusto do Pacote: " + Cost +
                   "\nData de Registro do Pacote: "+ DtRegistration +
                   "\nHotel: " + Hotel.ToString() +
                   "\n Passagem: " + Ticket.ToString() +
                   "\n Cliente: " + Client.ToString();

        }
        #endregion

    }
}
