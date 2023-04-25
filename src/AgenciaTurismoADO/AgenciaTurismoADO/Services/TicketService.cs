using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
        }
        public int Add(Ticket ticket)
        {

            return _ticketRepository.Add(ticket);
        }
        public List<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public int Update(Ticket ticket)
        {

            return _ticketRepository.Update(ticket);
        }

        public int Delete(Ticket ticket)
        {
            return _ticketRepository.Delete(ticket);
        }
    }
}