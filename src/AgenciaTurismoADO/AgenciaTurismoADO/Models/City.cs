﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class City
    {
        #region Constant


        #endregion



        #region Properties

        public int Id { get; set; }
        public string NameCity { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Nome da cidade: " + NameCity;
        }
        #endregion
    }
}
