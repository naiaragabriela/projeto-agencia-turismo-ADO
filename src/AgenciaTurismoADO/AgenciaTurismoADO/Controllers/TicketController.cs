using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class TicketController
    {
        public int Insert(Ticket ticket)
        {
            new AddressController().Insert(ticket.Origin);
            new AddressController().Insert(ticket.Destination);

            return new TicketService().InsertTicket(ticket);
        }

        public List<Ticket> FindAll()
        {
            return new TicketService().FindAll();
        }

        public int Update(Ticket ticket)
        {
            new AddressController().Update(ticket.Origin);
            new AddressController().Update(ticket.Destination);

            return new TicketService().Update(ticket);
        }

        public int Delete(int id)
        {
            return new TicketService().Delete(id);
        }
    }
}
