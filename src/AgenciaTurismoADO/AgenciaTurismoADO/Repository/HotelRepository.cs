﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class HotelRepository : IHotelRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Hotel hotel)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Hotel.INSERT, new
                {
                    NameHotel = hotel.NameHotel,
                    CostHotel = hotel.CostHotel,
                    DtRegistration = hotel.DtRegistration,
                    IdAddress= hotel.Address.Id
                });
            }
            return result;
        }

        public List<Hotel> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var hotel = db.Query<Hotel, Address, City, Hotel>(Hotel.SELECT, (hotel, address, city) =>
                {
                    address.City = city;
                    hotel.Address = address;
                    return hotel;
                }, splitOn: "SplitAddress, SplitCity");

                return (List<Hotel>)hotel;
            }
        }

        public int Update(Hotel hotel)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Hotel.UPDATE, new
                {
                    NameHotel = hotel.NameHotel,
                    CostHotel = hotel.CostHotel,
                    DtRegistration = hotel.DtRegistration,
                    IdAddress = hotel.Address.Id
                });
            }
            return result;
        }
    
        public int Delete(Hotel hotel)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Hotel.DELETE, hotel);
            }
            return result;
        }

    }

}
