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
    public class TicketRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Ticket ticket)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Ticket.INSERT, ticket);
            }
            return result;
        }

        public List<Ticket> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var ticket = db.Query<City>(Ticket.SELECT);
                return (List<Ticket>)ticket;
            }
        }
        public int Update(City city)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(City.UPDATE, city);
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
