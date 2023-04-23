using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Ticket
    {
        #region Constant
        public readonly static string INSERT = "INSERT INTO Ticket (IdOrigin, IdDestination, DtRegistration, CostTicket) " +
                       "VALUES (@IdOrigin, @IdDestination, @DtRegistration, @CostTicket); select cast(scope_identity() as int)";








        /*sb.Append("select ticket.Id AS IdTicket, ");
            sb.Append("       ticket.DtRegistration AS TicketResgistration,");
            sb.Append("       ticket.CostTicket AS CostTicket, ");
            sb.Append("       addressOrigin.Id AS IdOrigin, ");
            sb.Append("       addressOrigin.Street AS OriginStreet, ");
            sb.Append("       addressOrigin.Number AS OriginNumber, ");
            sb.Append("       addressOrigin.Neighborhood AS OriginNeighborhood, ");
            sb.Append("       addressOrigin.PostalCode AS OriginPostalCode, ");
            sb.Append("       addressOrigin.Complement AS OriginComplemnt, ");
            sb.Append("       addressOrigin.DtRegistration AS AddressOriginResgistration,");
            sb.Append("       cityOrigin.Id AS IdCityOrigin, ");
            sb.Append("       cityOrigin.NameCity AS NameCityOrigin, ");
            sb.Append("       cityOrigin.DtRegistration AS CityOriginResgistration,");
            sb.Append("       addressDestination.Id AS IdDestination, ");
            sb.Append("       addressDestination.Street AS DestinationStreet, ");
            sb.Append("       addressDestination.Number AS DestinationNumber, ");
            sb.Append("       addressDestination.Neighborhood AS DestinationNeighborhood, ");
            sb.Append("       addressDestination.PostalCode As DestinationPostalCode, ");
            sb.Append("       addressDestination.Complement AS DestinationComplement, ");
            sb.Append("       addressDestination.DtRegistration AS AddressDestinationResgistration,");
            sb.Append("       cityDestination.Id AS IdCityDestination, ");
            sb.Append("       cityDestination.NameCity AS NameCityDestination, ");
            sb.Append("       cityDestination.Registration AS CityOriginRegistration, ");
            sb.Append("       FROM [TICKET] client JOIN [ADDRESS] addressOrigin ON ticket.[IdOrigin] = address.[Id] "); 
            sb.Append("       JOIN [CITY] cityOrigin ON city.[Id] = address.[IdCity]");
            sb.Append("       JOIN [ADDRESS] addressDestination ON ticket.[IdDestination] = address.IdCity");
            sb.Append("       JOIN [CITY] cityDestination ON city.Id = address.IdCity");


        */

        public readonly static string SELECT =" ";

        public readonly static string UPDATE = "UPDATE Ticket SET " +
                                               "Origin = @IdOrigin, " +
                                               "Destination = @IdDestination, " +
                                               "CostTicket = @CostTicket " +
                                                "WHERE Id = @id";


        public readonly static string DELETE = "DELETE FROM Ticket WHERE id =@id";

        #endregion

        #region Properties
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public DateTime DtRegistration { get; set; }
        public decimal CostTicket { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id da Passagem: "+ Id+
                   "\nCusto da Passagem: " + CostTicket +
                   "\nData de Registro da Passagem: "+ DtRegistration +
                   "\nOrigem da Passagem: " + Origin.ToString() +
                   "\nDestino da Passagem: " + Destination.ToString();
        }
        #endregion
    }
}
