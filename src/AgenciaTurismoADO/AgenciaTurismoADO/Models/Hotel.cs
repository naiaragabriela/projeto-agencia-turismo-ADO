using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Hotel
    {
      
            #region Properties
            public int Id { get; set; }
            public string NameHotel { get; set; }
            public Address Address { get; set; }
            public decimal CostHotel { get; set; }
            public DateTime DtRegistration { get; set; }

            #endregion

            public override string ToString()
            {
                return "Nome:" + NameHotel +
                       "\nCusto do Hotel: " + CostHotel +
                       "\nEndereço: " + Address.ToString();
            }
        
    }
}
