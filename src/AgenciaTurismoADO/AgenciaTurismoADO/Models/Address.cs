using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Address
    {

        #region Constant


        #endregion

        #region Properties 
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return  "Id de endereço: " + Id +
                    "\nLogradouro: " + Street +
                    "\nNúmero: " + Number +
                    "\nBairro: " + Neighborhood +
                    "\nCEP: " + PostalCode +
                    "\nComplemento: " + Complement +
                    "\n Data do registro do Endereço: " + DtRegistration +
                    "\n" + City.ToString();
        }
        #endregion
    }
}
