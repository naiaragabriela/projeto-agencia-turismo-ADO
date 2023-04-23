﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AgenciaTurismoADO.Models;
using Dapper;

namespace AgenciaTurismoADO.Repository
{
    public class ClientRepository : IClientRepository
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo-ADO\src\banco\TourismAgencyADO.mdf";

        public int Add(Client client)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.ExecuteScalar(Client.INSERT, new
                {
                    Name = client.Name,
                    Phone = client.Phone,
                    DtRegistration = client.DtRegistration,
                    IdAddress = client.Address.Id,
                });
            }
            return result;
        }

        public List<Client> GetAll()
        {
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var client = db.Query<Client, Address, City, Client>(Client.SELECT, (client, address, city) =>
                {
                    address.City = city;
                    client.Address = address;
                    return client;
                }, splitOn: "SplitAddress,SplitCity");

                return (List<Client>)client;
            };
            
        }

        public int Update(Client client)
        {
            int result = 0;

        using (var db = new SqlConnection(strConn))
        {
            db.Open();
            result = (int)db.Execute(Client.UPDATE, client);
        }
            return result;
        }

        public int Delete(Client client)
        {
            int result = 0;

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                result = (int)db.Execute(Client.DELETE, client);
            }
            return result;
        }
    }
}
