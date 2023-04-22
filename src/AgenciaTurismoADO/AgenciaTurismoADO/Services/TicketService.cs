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
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";
        readonly SqlConnection conn;
        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }


        public int InsertTicket(Ticket ticket)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Ticket (IdOrigin, IdDestination, DtRegistration, CostTicket) " +
                       "values (@IdOrigin, @IdDestination, @DtRegistration, @CostTicket); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdOrigin", ticket.Origin.Id));
                commandInsert.Parameters.Add(new SqlParameter("@IdDestination", ticket.Destination.Id));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", ticket.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@CostTicket", ticket.CostTicket));

                status = (int)commandInsert.ExecuteScalar();
                ticket.Id = status;
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
        public List<Ticket> FindAll()
        {
            List<Ticket> ticketList = new List<Ticket>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select ticket.Id AS IdTicket, ");
            sb.Append("       ticket.DtRegistration AS TicketResgistration,");
            sb.Append("       ticket.CostTicket AS CostTicket, ");
            sb.Append("       addressOrigin.Id AS IdOrigin, ");
            sb.Append("       addressOrigin.Street AS OriginStreet, ");
            sb.Append("       addressOrigin.Number AS OriginNumber, ");
            sb.Append("       addressOrigin.Neighborhood AS OriginNeighborhood, ");
            sb.Append("       addressOrigin.PostalCode AS OriginPostalCode, ");
            sb.Append("       addressOrigin.Complement AS OriginComplemnt, ");
            sb.Append("       cityOrigin.Id AS IdCity, ");
            sb.Append("       cityOrigin.NameCity AS NameCityOrigin, ");
            sb.Append("       cityOrigin.DtRegistration AS CityOriginResgistration,");
            sb.Append("       addressDestination.Street AS DestinationStreet, ");
            sb.Append("       addressDestination.Number AS DestinationNumber, ");
            sb.Append("       addressDestination.Neighborhood AS DestinationNeighborhood, ");
            sb.Append("       addressDestination.PostalCode As DestinationPostalCode, ");
            sb.Append("       addressDestination.Complement AS DestinationComplement, ");

            sb.Append("       cityDestination.NameCity AS NameCityDestination, ");
            sb.Append("       FROM [TICKET] client JOIN [ADDRESS] addressOrigin ON ticket.[IdOrigin] = address.[Id] "); 
            sb.Append("       JOIN [CITY] cityOrigin ON city.[Id] = address.[IdCity]");
            sb.Append("       JOIN [ADDRESS] addressDestination ON ticket.[IdDestination] = address.IdCity");
            sb.Append("       JOIN [CITY] ON city.Id = address.IdCity");
            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket ticket = new Ticket();

                ticket.Id = (int)dr["IdTicket"];
                ticket.DtRegistration = (DateTime)dr["TicketResgistration"];
                ticket.CostTicket = (decimal)dr["CostTicket"];
                ticket.Origin = new Address()
                {
                    Street = (string)dr["OriginStreet,"],
                    Number = (int)dr["OriginNumber"],
                    Neighborhood = (string)dr["OriginNeighborhood"],
                    PostalCode = (string)dr["OriginPostalCode"],
                    Complement = (string)dr["OriginComplemnt"]
                };
                ticket.Destination = new Address()
                {
                    Street = (string)dr["DestinationStreet"],
                    Number = (int)dr["DestinationNumber"],
                    Neighborhood = (string)dr["DestinationNeighborhood"],
                    PostalCode = (string)dr["DestinationPostalCode"],
                    Complement = (string)dr["DestinationComplement"]
                };

                ticketList.Add(ticket);
            }
            return ticketList;
        }

        public int Update(Ticket ticket)
        {

            string _update = "UPDATE Ticket SET " +
                             "Origin = @IdOrigin, " +
                             "Destination = @IdDestination, " +
                             "CostTicket = @CostTicket " +
                             " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@IdSource", ticket.Origin.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@IdDestination", ticket.Destination.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@CostTicket", ticket.CostTicket));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(int id)
        {
            string _delete = "delete from Ticket where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}