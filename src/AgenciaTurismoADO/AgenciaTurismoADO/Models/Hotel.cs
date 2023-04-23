using System;
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

        /*
            sb.Append("select hotel.Id AS IdHotel, ");
            sb.Append("       hotel.Name AS NameHotel , ");
            sb.Append("       hotel.DtRegistration AS HotelRegistration , ");
            sb.Append("       hotel.CostHotel As CostHotel, ");
            sb.Append("       addressHotel.Id AS IdAddress, ");
            sb.Append("       addressHotel.Street AS StreetHotel, ");
            sb.Append("       addressHotel.Number AS NumberHotel, ");
            sb.Append("       addressHotel.Neighborhood AS NeighborhoodHotel, ");
            sb.Append("       addressHotel.PostalCode As PostalCodeHotel, ");
            sb.Append("       addressHotel.Complement AS ComplementHotel, ");
            sb.Append("       cityHotel.Id AS IdCity, ");
            sb.Append("       cityHotel.NameCity AS NameCityHotel, ");
            sb.Append("       cityHotel.DtRegistration AS CityRegistration, ");
            sb.Append("       FROM [HOTEL] hotel JOIN [ADDRESS] addressHotel ON hotel.[IdAddress] = addressHotel.[Id] ");
            sb.Append("       JOIN [CITY] cityHotel ON cityHotel.[Id] = addressHotel.[IdCity]");
        */


        public readonly static string SELECT ="SELECT HOTEL Id, DtRegistration, CostHotel, IdAddress, Street, Number, Neigborhood, PostalCode, Complement"
            "FROM HOTEL JOIN ADDRESS ON hotel.IdAddress = address.Id"+
            "JOIN CITY ON city.Id= anddress.Id";


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
