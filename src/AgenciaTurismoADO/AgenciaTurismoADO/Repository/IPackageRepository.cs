using AgenciaTurismoADO.Models;

namespace AgenciaTurismoADO.Repository
{
    public interface IPackageRepository
    {
        int Add(Package package);

        List<Package> GetAll();

        int Update(Package package);

        int Delete(Package package);
    }
}
