using System.Net.Sockets;
using AgenciaTurismoADO.Controllers;
using AgenciaTurismoADO.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Projeto ADO - Agencia Turismo");


        #region CITY 

        #region CREATE CITY

        City cityOne = new City()
        {
            Id = 1,
            NameCity = "Matao",
            DtRegistration = DateTime.Now
        };

        City cityTwo = new City()
        {
            NameCity = "Bauru",
            DtRegistration = DateTime.Now
        };

        City cityHotel = new City()
        {
            Id = 3,
            NameCity = "São Paulo",
            DtRegistration = DateTime.Now
        };


        /*
        if (new CityController().Insert(cityOne) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new CityController().Insert(cityTwo) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new CityController().Insert(cityHotel) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        #endregion

        #region SELECT CITY
        /*
        new CityController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));
        */
        #endregion

        #region UPDATE CITY
        /*

        if  (new CityController().Update(cityOne) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        */

        #endregion

        #region DELETE CITY
        /*

        if (new CityController().Delete(2) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        #endregion

        #endregion;


        #region  ADDRESS

        #region CREATE ADDRESS

        Address addressHotel = new Address()
        {
            Id = 3,
            Street = "Rua Augusta",
            Number = 150,
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Complement = "Apto 123, Bloco C",
            DtRegistration = DateTime.Now,
            City = cityHotel
        };

        Address addressOrigin = new Address()
        {
            Street = "Rua Feliz",
            Number = 100,
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Complement = "Apto 23, Bloco F",
            DtRegistration = DateTime.Now,
            City = cityOne
        };

        Address addressDestination = new Address()
        {
            Street = "Rua Origem",
            Number = 200,
            Neighborhood = "Vivendo",
            PostalCode = "123456-188",
            Complement = "Apto 2, Bloco A",
            DtRegistration = DateTime.Now,
            City = cityHotel
        };

        /*

        if (new AddressController().Insert(addressHotel) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(addressSource) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(addressDestination) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        */

        #endregion

        #region SELECT ADDRESS
        /*
        new AddressController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));
        */
        #endregion

        #region UPDATE ADDRESS
        /*

        if (new AddressController().Update(addressHotel) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */
        #endregion

        #region DELETE ADDRESS

        /*
        if (new AddressController().Delete(4) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */
        #endregion

        #endregion;


        #region  CLIENT

        #region CREATE CLIENT
        Client clientOne = new Client()
        {
            Name = "Gustavo",
            Phone = "7070-7070",
            DtRegistration = DateTime.Now,
            Address = addressOrigin
        };

        Client clientTwo = new Client()
        {
            Name = "ANA",
            Phone = "1010-3030",
            DtRegistration = DateTime.Now,
            Address = addressDestination
        };

        if (new ClientController().Insert(clientOne) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new ClientController().Insert(clientTwo) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion

        #region SELECT CLIENT

        new ClientController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));

        #endregion

        #region UPDATE CLIENT

        if (new ClientController().Update(clientOne) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");
        #endregion

        #region DELETE CLIENT

        if (new AddressController().Delete(7) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion


        #endregion;


        #region  TICKET

        #region CREATE TICKET
        Ticket ticketOne = new Ticket
        {
            Origin = addressOrigin,
            Destination = addressDestination,
            CostTicket = 200,
            DtRegistration = DateTime.Now,
        };


        if (new TicketController().Insert(ticketOne) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");



        #endregion

        #region SELECT TICKET

        new TicketController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));

        #endregion

        #region UPDATE TICKET


        if (new TicketController().Update(ticketOne) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");


        #endregion

        #region DELETE TICKET

        if (new TicketController().Delete(8) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");


        #endregion

        #endregion;


        #region HOTEL

        #region CREATE HOTEL
        Hotel hotel = new Hotel()
        {
            NameHotel = "Hotel Felicidade",
            Address = addressHotel,
            CostHotel = 300,
            DtRegistration = DateTime.Now,
        };

        #endregion

        #region SELECT HOTEL
        new HotelController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));

        #endregion

        #region UPDATE HOTEL

        if (new HotelController().Update(hotel) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion

        #region DELETE HOTEL

        if (new HotelController().Delete(8) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion


        #endregion;



        #region  PACKAGE

        #region CREATE PACKAGE

        Package package = new Package()
        {
            Hotel = hotel,
            Ticket = ticketOne,
            Client = clientOne,
            Cost = 500,
            DtRegistration = DateTime.Now,
        };


        if (new PackageController().Insert(package) > 0)
            Console.WriteLine("Sucesso! Pacote Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        #endregion

        #region SELECT PACKAGE
        new PackageController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));

        #endregion

        #region UPDATE PACKAGE

        if (new PackageController().Update(package) > 0)

            Console.WriteLine("Sucesso! Update completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion

        #region DELETE PACKAGE


        #endregion


        if (new HotelController().Delete(8) > 0)

            Console.WriteLine("Sucesso! Delete completo!");
        else
            Console.WriteLine("Erro ao inserir registro");

        #endregion;


    }
}