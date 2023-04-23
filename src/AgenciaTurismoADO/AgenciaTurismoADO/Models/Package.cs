﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Package
    {
        #region Constant


        #endregion

        #region Properties
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DtRegistration { get; set; }
        public decimal Cost { get; set; }
        public Client Client { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Custo do Pacote: " + Cost +
                   "\nHotel: " + Hotel.ToString() +
                   "\n Passagem: " + Ticket.ToString() +
                   "\n Cliente: " + Client.ToString();

        }
        #endregion

    }
}
