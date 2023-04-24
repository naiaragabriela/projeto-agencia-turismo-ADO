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
        public readonly static string INSERT = "INSERT INTO Package (IdHotel, IdTicket, DtRegistration, Cost, IdClient)" +
                    "VALUES (@IdHotel, @IdTicket, @DtRegistration, @Cost, @IdClient); select cast(scope_identity() as int)";



        public readonly static string SELECT = @"SELECT [Package].Id AS Id, [Package].Cost, [Package].DtRegistration, [Client].[Id] AS SplitClient,  
[Client].[Id] AS Id, [Client].[Name], [Client].[Phone], [Client].[DtRegistration], [AddressClient].[Id] AS SplitAddressClient, 
[AddressClient].[Id] AS Id, [AddressClient].[Street],[AddressClient].[Number],[AddressClient].[Neighborhood], [AddressClient].[PostalCode],
[AddressClient].[Complement],[AddressClient].[DtRegistration], [AddressCity].[Id] AS SplitCityClient, [AddressCity].[Id] AS Id, [AddressCity].[NameCity],
[AddressCity].[DtRegistration], [Hotel].[Id] AS SplitHotel, [Hotel].[Id] AS Id,[Hotel].[Name], [CostHotel], [Hotel].[DtRegistration],[AddressHotel].[Id] AS SplitAddressHotel, 
[AddressHotel].[Id] AS Id, [AddressHotel].[Street], [AddressHotel].[Number],[AddressHotel].[Neighborhood],[AddressHotel].[PostalCode], 
[AddressHotel].[Complement], [AddressHotel].[DtRegistration], [AddressCityHotel].[Id] AS SplitCityHotel, [AddressCityHotel].[Id] AS Id,
[AddressCityHotel].[NameCity], [AddressCityHotel].[DtRegistration],[Ticket].[Id] AS SplitTicket, [Ticket].[Id] AS Id, [CostTicket], 
[Ticket].[DtRegistration], [Ticket].[IdOrigin] AS SplitOrigin, [AddressOrigin].[Id] AS Id, [AddressOrigin].[Street], [AddressOrigin].[Number], 
[AddressOrigin].[Neighborhood], [AddressOrigin].[PostalCode], [AddressOrigin].[Complement], [AddressOrigin].[DtRegistration], 
[CityOrigin].[Id] AS SplitCityOrigin, [CityOrigin].[Id] AS Id, [CityOrigin].[NameCity], [CityOrigin].[DtRegistration], 
[Ticket].[IdDestination] AS SplitDestination, [AddressDestination].[Id] AS Id, [AddressDestination].[Street], [AddressDestination].[Number] ,
[AddressDestination].[Neighborhood], [AddressDestination].[PostalCode], [AddressDestination].[Complement], [AddressDestination].[DtRegistration], 
[CityDestination].[Id] AS SplitCityDestination,[CityDestination].[Id] AS Id, [CityDestination].[NameCity], [CityDestination].[DtRegistration]
FROM [Package] 
JOIN [Client] ON [Package].IdClient = [Client].Id  
JOIN [Address] AddressClient ON [Client].IdAddress = [AddressClient].Id  
JOIN [City] AddressCity ON [AddressClient].IdCity = [AddressCity].Id  
JOIN [Hotel] ON [Package].IdHotel = [Hotel].Id  
JOIN [Address] AddressHotel ON [Hotel].IdAddress = [AddressHotel].Id  
JOIN [City] AddressCityHotel ON [AddressHotel].IdCity= [AddressCityHotel].Id 
JOIN [Ticket] ON [Package].IdTicket = [Ticket].Id  
JOIN [Address] AddressOrigin ON [Ticket].IdOrigin = [AddressOrigin].Id  
JOIN [City] CityOrigin ON [AddressOrigin].IdCity = [CityOrigin].Id  
JOIN [Address] AddressDestination ON [Ticket].IdDestination = [AddressDestination].Id  
JOIN [City] CityDestination ON [AddressDestination].IdCity = [CityDestination].Id ";


        public readonly static string UPDATE = "UPDATE Package SET " +
                                               "Hotel = @IdHotel" +
                                               "Ticket = @IdTicket" +
                                               "Client = @IdClient" +
                                               "Cost = @Cost" +
                                                 "WHERE Id = @id";

        public readonly static string DELETE = "DELETE FROM PACKAGE WHERE Id = @Id";

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
            return "Id do Pacote: "+ Id+
                   "\nCusto do Pacote: " + Cost +
                   "\nData de Registro do Pacote: "+ DtRegistration +
                   "\nHotel: " + Hotel.ToString() +
                   "\n Passagem: " + Ticket.ToString() +
                   "\n Cliente: " + Client.ToString();

        }
        #endregion

    }
}
