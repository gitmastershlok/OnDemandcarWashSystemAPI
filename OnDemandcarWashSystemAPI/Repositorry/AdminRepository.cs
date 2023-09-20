using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class AdminRepository : IAdmin
	{
		private CarWashContext adminDb;
		public AdminRepository(CarWashContext adminDbContext)
		{
			adminDb = adminDbContext;
		}
		public List<Admin> GetAllAdmin()
		{
			List<Admin> admins = null;
			try
			{
				admins = adminDb.Admins.ToList();
			}
			catch (Exception) { }
			return admins;
		}
		public Admin GetAdmin(int id)
		{
			Admin? admin;
			try
			{
				admin = adminDb.Admins.Find(id);
				if (admin != null)
				{
					return admin;
				}
			}
			catch (Exception)
			{
				throw new ArgumentNullException();
			}
			finally
			{
				admin = null;
			}
			return admin;
		}
		public string AddAdmin(Admin admin)
		{
			string result = string.Empty;
			try
			{
				adminDb.Admins.Add(admin);
				adminDb.SaveChanges();
			}
			catch (Exception)
			{
				result = "400";
			}
			return result;
		}
		public string UpdateAdmin(Admin admin)
		{
			string result = string.Empty;
			try
			{
				adminDb.Entry(admin).State = EntityState.Modified;
				adminDb.SaveChanges();
				result = "200";
			}
			catch
			{
				result = "400";
			}
			return result;
		}
		public string DeleteAdmin(int id)
		{
			string result = string.Empty;
			Admin? admin;
			try
			{
				admin = adminDb.Admins.Find(id);
				if (admin != null)
				{
					//package.Status = "In Active";
					adminDb.Admins.Remove(admin);
					adminDb.SaveChanges();
					result = "200";
				}
			}
			catch (Exception)
			{
				result = "400";
			}
			finally
			{
				admin = null;
			}
			return result;
		}
	}
}
