using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Interfaces;

namespace OnDemandcarWashSystemAPI.Services
{
	public class PackageService
	{
		private IPackage _IPackage;
		public PackageService(IPackage Ipackage)
		{
			_IPackage = Ipackage;
		}
		public List<Package> GetAllPackage()
		{
			return _IPackage.GetAllPackage();
		}
		public Package GetPackage(int id)
		{
			return _IPackage.GetPackage(id);
		}
		public string AddPackage(Package package)
		{
			return _IPackage.AddPackage(package);
		}
		public string UpdatePackage(Package package)
		{
			return _IPackage.UpdatePackage(package);
		}
		public string DeletePackage(int id)
		{
			return _IPackage.DeletePackage(id);
		}
	}
}
