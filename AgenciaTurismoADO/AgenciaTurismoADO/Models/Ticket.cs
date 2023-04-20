using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Ticket
    {
        #region Properties
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime DtRegistration { get; set; }
        public decimal CostTicket { get; set; }
        #endregion

        public override string ToString()
        {
            return "Custo: " + CostTicket +
                   "\nOrigem da Passagem: " + Origin.ToString() +
                   "\nDestino da Passagem: " + Destination.ToString() +
                   "\nCliente da Passagem: " + Client.ToString();
        }
    }
}
