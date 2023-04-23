using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismoADO.Models
{
    public class Address
    {

        #region Constant

        public readonly static string INSERT = "INSERT INTO ADDRESS(Street, Number, Neighborhood, PostalCode, Complement, DtRegistration, IdCity) " +
                    "VALUES (@Street, @Number, @Neighborhood, @PostalCode, @Complement, @DtRegistration, @IdCity); " +
                    "select cast(scope_identity() as int)";
 
        /*sb.Append("select address.Id AS IdAddress, ");
            sb.Append("       address.DtRegistration, ");
            sb.Append("       address.Street, ");
            sb.Append("       address.Number, ");
            sb.Append("       address.Neighborhood, ");
            sb.Append("       address.PostalCode, ");
            sb.Append("       address.Complement,");
            sb.Append("       city.Id AS IdCity, ");
            sb.Append("       city.NameCity, ");
            sb.Append("       city.DtRegistration As CityRegistration ");
            sb.Append("       from Address address,");
            sb.Append("       City city");
            sb.Append("       where address.IdCity = city.Id");

        */
                 

        //preciso organizar isso aqui 

        public readonly static string SELECT = "SELECT Id, DtRegistration, Street, Number Neighborhood, PostalCode, Complement FROM ADDRESS" +
                                               "WHERE Address.IdCity = City.Id";

        public readonly static string UPDATE = "UPDATE ADDRESS SET Street = @Street" +
                                               "Number = @Number, " +
                                               "Neighborhood = @Neighborhood, " +
                                               "PostalCode = @PostalCode, " +
                                               "Complement = @Complement, " +
                                               "City = @IdCity "+
                                               "where id = @id";

        public readonly static string DELETE = "DELETE FROM ADDRESS WHERE Id = @Id";
        #endregion

        #region Properties 
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id de endereço: " + Id +
                    "\nLogradouro: " + Street +
                    "\nNúmero: " + Number +
                    "\nBairro: " + Neighborhood +
                    "\nCEP: " + PostalCode +
                    "\nComplemento: " + Complement +
                    "\n Data do registro do Endereço: " + DtRegistration +
                    "\n" + City.ToString();
        }
        #endregion
    }
}
