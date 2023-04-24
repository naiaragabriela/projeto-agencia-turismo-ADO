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
        public readonly static string INSERT = "INSERT INTO HOTEL(Name, IdAddress, CostHotel, DtRegistration) " +
                       "VALUES (@Name, @IdAddress, @CostHotel, @DtRegistration); select cast(scope_identity() as int)";

     


        public readonly static string SELECT = "SELECT [Hotel].[Id] AS Id, [Hotel].[Name], [Hotel].[CostHotel],[Hotel].[DtRegistration]," +
            "[AddressHotel].[Id] AS SplitAddress, [AddressHotel].[Id] AS Id, [Street],[Number],[Neighborhood],[PostalCode],[Complement]," +
            "[AddressHotel].[DtRegistration],[AddressCity].[Id] AS SplitCity, [AddressCity].[Id] AS Id, [AddressCity].[NameCity], [AddressCity].[DtRegistration] " +
            "FROM [Hotel] JOIN [Address] AddressHotel ON IdAddress = AddressHotel.Id " +
            "JOIN [City] AddressCity ON AddressHotel.IdCity= AddressCity.Id";

        public readonly static string UPDATE = "UPDATE Hotel SET " +
                                               "NameHotel = @NameHotel" +
                                               "Address = @IdAdress" +
                                               "CostHotel = @CostHotel" +
                                              " WHERE Id = @id";


        public readonly static string DELETE = "DELETE FROM Hotel WHERE Id =@id";

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
            return "Id do Hotel: " + Id+
                   "Nome:" + Name +
                   "\nCusto do Hotel: " + CostHotel +
                   "\nData de Registro do Hotel: "+ DtRegistration +
                   "\nEndereço: " + Address.ToString();
        }
        #endregion

    }
}
