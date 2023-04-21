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
        public int Insert(Package package)
        {
            new HotelController().Insert(package.Hotel);
            new TicketController().Insert(package.Ticket);
            new ClientController().Insert(package.Client);

            return new PackageService().InsertPackage(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public int Update(Package package)
        {
            new HotelController().Update(package.Hotel);
            new TicketController().Update(package.Ticket);
            new ClientController().Update(package.Client);

            return new PackageService().Update(package);
        }

        public int Delete(int id)
        {
            return new PackageService().Delete(id);
        }


    }
}
