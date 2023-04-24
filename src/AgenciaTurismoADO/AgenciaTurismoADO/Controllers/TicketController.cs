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

        public readonly static string SELECT = @" SELECT [Ticket].[Id] AS Id, [CostTicket], [Ticket].[DtRegistration],
         [AddressOrigin].[Id] AS Id, [AddressOrigin].[Street], [AddressOrigin].[Number],
             [AddressOrigin].[Neighborhood], [AddressOrigin].[PostalCode], [AddressOrigin].[Complement], [AddressOrigin].[DtRegistration], 
            [CityOrigin].[Id] AS Id, [CityOrigin].[NameCity], [CityOrigin].[DtRegistration], 
            [AddressDestination].[Id] AS Id, [AddressDestination].[Street],[AddressDestination].[Number] ,[AddressDestination].[Neighborhood],
         [CityDestination].[Id] AS Id,[CityDestination].[NameCity], [CityDestination].[DtRegistration] 
            FROM[Ticket]
            JOIN[Address] AddressOrigin ON IdOrigin = AddressOrigin.Id  
            JOIN[City] CityOrigin ON AddressOrigin.IdCity = CityOrigin.Id  
            JOIN[Address] AddressDestination ON IdDestination = AddressDestination.Id  
            JOIN[City] CityDestination ON AddressDestination.IdCity = CityDestination.Id";

        public int Insert(Ticket ticket)
        {

            return new TicketService().InsertTicket(ticket);
        }

        public List<Ticket> FindAll(string SELECT)
        {
            return new TicketService().FindAll(SELECT);
        }

        public int Update(Ticket ticket)
        {

            return new TicketService().Update(ticket);
        }

        public int Delete(int id)
        {
            return new TicketService().Delete(id);
        }
    }
}
