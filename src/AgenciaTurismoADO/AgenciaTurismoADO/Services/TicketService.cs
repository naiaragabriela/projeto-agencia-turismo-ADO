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
        public List<Ticket> FindAll(string SELECT)
        {
            List<Ticket> ticketList = new List<Ticket>();

        
            SqlCommand commandSelect = new SqlCommand(SELECT, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket ticket = new Ticket();

                ticket.Id = (int)dr["Id"];
                ticket.DtRegistration = (DateTime)dr["DtResgistration"];
                ticket.CostTicket = (decimal)dr["CostTicket"];
                ticket.Origin = new Address()
                {
                    Id = (int)dr["IdOrigin"], 
                    Street = (string)dr["OriginStreet,"],
                    Number = (int)dr["OriginNumber"],
                    Neighborhood = (string)dr["OriginNeighborhood"],
                    PostalCode = (string)dr["OriginPostalCode"],
                    Complement = (string)dr["OriginComplemnt"],
                    DtRegistration = (DateTime)dr["AddressOriginResgistration"],
                    City = new City()
                    {
                        Id = (int)dr["IdCityOrigin"],
                        NameCity = (string)dr["NameCityOrigin"],
                        DtRegistration = (DateTime)dr["CityOriginResgistration"],
                    }
                };
                ticket.Destination = new Address()
                {
                    Id = (int)dr["Id"],
                    Street = (string)dr["Street"],
                    Number = (int)dr["Number"],
                    Neighborhood = (string)dr["Neighborhood"],
                    PostalCode = (string)dr["PostalCode"],
                    Complement = (string)dr["Complement"],
                    DtRegistration = (DateTime)dr["DtResgistration"],
                    City = new City()
                    {
                        Id = (int)dr["Id"],
                        NameCity = (string)dr["NameCity"],
                        DtRegistration = (DateTime)dr["DtRegistration"],
                    }
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