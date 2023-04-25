using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class TicketController
    {
        public int Add(Ticket ticket)
        {

            return new TicketService().Add(ticket);
        }

        public List<Ticket> GetAll()
        {
            return new TicketService().GetAll();
        }

        public int Update(Ticket ticket)
        {
            return new TicketService().Update(ticket);
        }

        public int Delete(Ticket ticket)
        {
            return new TicketService().Delete(ticket);
        }
    }
}
