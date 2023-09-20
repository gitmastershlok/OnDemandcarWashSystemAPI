using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class PackageRepository : IPackage
	{
		private CarWashContext packageDb;
		public PackageRepository(CarWashContext packageDbContext)
		{
			packageDb = packageDbContext;
		}
		#region GetAllPackage
		public List<Package> GetAllPackage()
		{
			List<Package> packages = null;
			try
			{
				packages = packageDb.Packages.ToList();
			}
			catch (Exception) { }
			return packages;
		}
		#endregion
		#region GetPackageById
		public Package GetPackage(int id)
		{
			Package? package;
			try
			{
				package = packageDb.Packages.Find(id);
				if (package != null)
				{
					return package;
				}
			}
			catch (Exception)
			{
				throw new ArgumentNullException();
			}
			finally
			{
				package = null;
			}
			return package;
		}
		#endregion
		#region AddPackage
		public string AddPackage(Package package)
		{
			string result = string.Empty;
			try
			{
				packageDb.Packages.Add(package);
				packageDb.SaveChanges();
			}
			catch (Exception)
			{
				result = "400";
			}
			return result;
		}
		#endregion
		#region UpdatePackage
		public string UpdatePackage(Package package)
		{
			string result = string.Empty;
			try
			{
				packageDb.Entry(package).State = EntityState.Modified;
				packageDb.SaveChanges();
				result = "200";
			}
			catch
			{
				result = "400";
			}
			return result;
		}
		#endregion
		#region DeletePackage
		public string DeletePackage(int id)
		{
			string result = string.Empty;
			Package package;
			try
			{
				package = packageDb.Packages.Find(id);
				if (package != null)
				{
					//package.Status = "In Active";
					packageDb.Packages.Remove(package);
					packageDb.SaveChanges();
					result = "200";
				}
			}
			catch (Exception)
			{
				result = "400";
			}
			finally
			{
				package = null;
			}
			return result;
		}
		#endregion
	}
}
