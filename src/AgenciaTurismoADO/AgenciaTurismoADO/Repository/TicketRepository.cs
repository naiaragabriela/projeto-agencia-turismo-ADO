using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class TicketRepository: ITicketRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Ticket ticket)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Ticket.INSERT, new
                {
                    IdOrigin = ticket.Origin.Id,
                    IdDestination = ticket.Destination.Id,
                    DtRegistration = ticket.DtRegistration,
                    CostTicket = ticket.CostTicket

                });
            }
            return result;
        }

        public List<Ticket> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var ticket= db.Query<Ticket, Address, City, Address, City, Ticket>(Ticket.SELECT, (ticket, addressOrigin, cityOrigin,
                    addressDestination, cityDestination) =>
                {
                    addressOrigin.City = cityOrigin;
                    ticket.Origin = addressOrigin;
                    addressDestination.City = cityDestination;
                    ticket.Destination= addressDestination;

                    return ticket;
                }, splitOn: "SplitOrigin, SplitCityOrigin, SplitDestination, SplitCityDestination");

                return (List<Ticket>)ticket;
            }
        }
        public int Update(Ticket ticket)
        {

            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Ticket.UPDATE, new
                {
                    IdOrigin = ticket.Origin.Id,
                    IdDestination = ticket.Destination.Id,
                    DtRegistration = ticket.DtRegistration,
                    CostTicket = ticket.CostTicket

                });
            }
            return result;
        }

        public int Delete(Ticket ticket)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Ticket.DELETE,ticket);
            }
            return result;

        }
    }
}
