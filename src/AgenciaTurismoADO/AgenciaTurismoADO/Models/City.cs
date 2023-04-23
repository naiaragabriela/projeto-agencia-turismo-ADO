using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class City
    {
        #region Constant

        public readonly static string INSERT = "INSERT INTO CITY (NameCity, DtRegistration) VALUES (@NameCity,DtRegistration)";

        #endregion



        #region Properties

        public int Id { get; set; }
        public string NameCity { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id da cidade: "+ Id +
                "\nNome da cidade: " + NameCity +
                "\nData do registro da Cidade: " + DtRegistration;
        }
        #endregion
    }
}
