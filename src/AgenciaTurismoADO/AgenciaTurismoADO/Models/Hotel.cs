﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Hotel
    {
        #region Constant


        #endregion


        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public decimal CostHotel { get; set; }
        public DateTime DtRegistration { get; set; }

        #endregion

        #region Methods
        public override string ToString()
        {
            return "Nome:" + Name +
                   "\nCusto do Hotel: " + CostHotel +
                   "\nEndereço: " + Address.ToString();
        }
        #endregion

    }
}
