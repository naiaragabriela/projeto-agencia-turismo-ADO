using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Client
    {

        #region Constant


        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime DtRegistration { get; set; }

        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id do Cliente: "+ Id+
                   "\nNome: " + Name +
                   "\nPhone: " + Phone +
                   "\nData de Registro do Cliente: "+ DtRegistration+
                   "\nEndereço: " + Address.ToString();
        }
        #endregion
    }
}

