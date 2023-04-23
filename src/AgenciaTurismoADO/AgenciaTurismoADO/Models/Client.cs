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
        public readonly static string INSERT = "INSERT INTO CLIENT (Name, Phone, DtRegistration, IdAddress) " +
                    "VALUES (@Name, @Phone, @DtRegistration,@IdAddress); select cast(scope_identity() as int)";


        /*
        sb.Append("select client.Id AS IdClient, ");
            sb.Append("       client.Name AS NameClient, ");
            sb.Append("       client.Phone AS PhoneClient, ");
            sb.Append("       client.DtRegistration AS ClientRegistration , ");
            sb.Append("       addressClient.Id AS IdAddress, ");
            sb.Append("       addressClient.Street As StreetClient, ");
            sb.Append("       addressClient.Number AS NumberClient, ");
            sb.Append("       addressClient.Neighborhood AS NeighborhoodClient,");
            sb.Append("       addressClient.PostalCode AS PostalCodeClient, ");
            sb.Append("       addressClient.Complement AS ComplementClient, ");
            sb.Append("       addressClient.DtRegistration AS AddressRegistration , ");
            sb.Append("       city.Id AS IdCity, ");
            sb.Append("       city.NameCity As NameCityClient, ");
            sb.Append("       city.DtRegistration As RegistrationCityClient, ");
            sb.Append("       FROM [ClIENT] client JOIN [ADDRESS] addressClient ON client.[IdAddress] = addressClient.[Id] ");
            sb.Append("       JOIN [CITY] city ON city.[Id] = addressClient.[IdCity]");

        */
        public readonly static string SELECT = "SELECT Id, Name, Phone, IdAddress,Street, Number, Neighborhood, PostalCode,Complement, DtRegsitration" +
            "FROM CLIENT JOIN ADDRESS ON client.IdAddress = address.Id" +
            "JOIN CITY ON city.Id = address.Id" ;


        public readonly static string UPDATE = "UPDATE CLIENT SET " +
                                               "Name = @Name," +
                                               "Phone = @Phone," +
                                               "Address= IdAddress " +
                                              " WHERE Id = @id";


        public readonly static string DELETE = "DELETE FROM CLIENT WHERE id =@id";

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

