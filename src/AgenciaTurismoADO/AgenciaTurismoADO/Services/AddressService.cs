﻿using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService()
        {
            _addressRepository = new AddressRepository();
        }
        public int Add(Address address)
        {
            return _addressRepository.Add(address);
        }

        public List<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public int Update(Address address)

        {
            return _addressRepository.Update(address);
        }

        public int Delete(Address address)
        {
            return _addressRepository.Delete(address);
        }


    }
}
