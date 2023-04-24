using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Services;

namespace AgenciaTurismoADO.Controllers
{
    public class PackageController
    {

        public readonly static string SELECT = @"SELECT [Package].Id AS Id, [Package].Cost, [Package].DtRegistration, [Client].[Id] AS IdClient, [Client].[Name] AS NameClient, 
    [Client].[Phone] AS PhoneClient, [Client].[DtRegistration] AS ClientRegistration, [AddressClient].[Id] AS IdAddress, [AddressClient].[Street] AS StreetClient,
    [AddressClient].[Number] AS NumberClient,[AddressClient].[Neighborhood] AS NeighborhoodClient, [AddressClient].[PostalCode] AS PostalCodeClient,
    [AddressClient].[Complement] AS ComplementClient,[AddressClient].[DtRegistration] AS AddressRegistration,  [AddressCity].[Id] AS IdCity, 
    [AddressCity].[NameCity] AS NameCityClient, [AddressCity].[DtRegistration] AS RegistrationCityClient, [Hotel].[Id] AS IdHotel ,[Hotel].[Name] AS NameHotel,
    [CostHotel] AS CostHoteL, [Hotel].[DtRegistration] AS ClientRegistration,[AddressHotel].[Id] AS IdAddressHotel, [AddressHotel].[Street] AS StreetHotel,
    [AddressHotel].[Number] AS NumberHotel,[AddressHotel].[Neighborhood] AS NeighborhoodHotel,[AddressHotel].[PostalCode] AS PostalCodeHotel, [AddressHotel].[Complement] AS ComplementHotel, 
    [AddressHotel].[DtRegistration] AS RegistrationHotel, [AddressCityHotel].[Id] AS IdCityHotel, [AddressCityHotel].[NameCity] AS NameCityHotel,
    [AddressCityHotel].[DtRegistration] AS CityRegistration, [Ticket].[Id] AS IdTicket, [CostTicket] AS CostTicket, [Ticket].[DtRegistration] AS TicketResgistration, 
    [AddressOrigin].[Id] AS IdOrigin, [AddressOrigin].[Street] AS OriginStreet, [AddressOrigin].[Number] AS OriginNumber, [AddressOrigin].[Neighborhood] AS OriginNeighborhood, 
    [AddressOrigin].[PostalCode] AS OriginPostalCode, [AddressOrigin].[Complement] AS OriginComplemnt, [AddressOrigin].[DtRegistration] AS OriginResgistration,
    [CityOrigin].[Id] AS IdCityOrigin, [CityOrigin].[NameCity] AS NameCityOrigin, [CityOrigin].[DtRegistration] AS CityOriginResgistration, 
    [AddressDestination].[Id] AS IdDestination, [AddressDestination].[Street] AS DestinationStreet, [AddressDestination].[Number] AS DestinationNumber ,
    [AddressDestination].[Neighborhood] AS DestinationNeighborhood, [AddressDestination].[PostalCode] AS DestinationPostalCode, [AddressDestination].[Complement] AS DestinationComplement,
    [AddressDestination].[DtRegistration] AS DestinationResgistration, [CityDestination].[Id] AS IdCityDestination, [CityDestination].[NameCity] AS NameCityDestination, [CityDestination].[DtRegistration] AS CityDestinationRegistration
     FROM [Package]
     JOIN [Client] ON package.IdClient = client.Id 
     JOIN [Address] AddressClient ON client.IdAddress = AddressClient.Id 
     JOIN [City] AddressCity ON AddressClient.IdCity= AddressCity.Id 
     JOIN [Hotel] ON package.IdHotel = hotel.Id 
     JOIN [Address] AddressHotel ON hotel.IdAddress = AddressHotel.Id 
     JOIN [City] AddressCityHotel ON AddressHotel.IdCity= AddressCity.Id 
     JOIN [Ticket] ON package.IdTicket = ticket.Id 
     JOIN [Address] AddressOrigin ON IdOrigin = AddressOrigin.Id 
     JOIN [City] CityOrigin ON AddressOrigin.IdCity = CityOrigin.Id 
     JOIN [Address] AddressDestination ON IdDestination = AddressDestination.Id 
     JOIN [City] CityDestination ON AddressDestination.IdCity = CityDestination.Id";

        public int Insert(Package package)
        {
         
            return new PackageService().InsertPackage(package);
        }

        public List<Package> FindAll(string SELECT)
        {
            return new PackageService().FindAll(SELECT);
        }

        public int Update(Package package)
        {
        

            return new PackageService().Update(package);
        }

        public int Delete(int id)
        {
            return new PackageService().Delete(id);
        }


    }
}
