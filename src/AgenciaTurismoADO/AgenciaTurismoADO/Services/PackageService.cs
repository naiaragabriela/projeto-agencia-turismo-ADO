using AgenciaTurismoADO.Models;
using AgenciaTurismoADO.Repository;

namespace AgenciaTurismoADO.Services
{
    public class PackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService()
        {
            _packageRepository = new PackageRepository();
        }
        public int Add(Package package)
        {
            return _packageRepository.Add(package);
        }

        public List<Package> GetAll()
        {
            return _packageRepository.GetAll();

        }

        public int Update(Package package)
        {

            return _packageRepository.Update(package);
        }

        public int Delete(Package package)
        {
            return _packageRepository.Delete(package);
        }


    }
}
