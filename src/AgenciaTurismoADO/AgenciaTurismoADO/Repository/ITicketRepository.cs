using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public interface ITicketRepository
    {

        int Add(Ticket ticket);

        List<Ticket> GetAll();

        int Update(Ticket ticket);

        int Delete(Ticket ticket);
    }
}
