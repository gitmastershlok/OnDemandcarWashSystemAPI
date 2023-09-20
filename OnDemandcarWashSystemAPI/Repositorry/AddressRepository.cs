using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class AddressRepository : IAddress
	{
		private CarWashContext addressDb;
		public AddressRepository(CarWashContext addressDbContext)
		{
			addressDb = addressDbContext;
		}
		public List<Address> GetAllAddress()
		{
			List<Address> address = null;
			try
			{
				address = addressDb.Address.ToList();
			}
			catch (Exception) { }
			return address;
		}
		public Address GetAddress(int id)
		{
			Address? address;
			try
			{
				address = addressDb.Address.Find(id);
				if (address != null)
				{
					return address;
				}
			}
			catch (Exception)
			{
				throw new ArgumentNullException();
			}
			finally
			{
				address = null;
			}
			return address;
		}
		public string AddAddress(Address address)
		{
			string result = string.Empty;
			try
			{
				addressDb.Address.Add(address);
				addressDb.SaveChanges();
			}
			catch (Exception)
			{
				result = "400";
			}
			return result;
		}
		public string UpdateAddress(Address address)
		{
			string result = string.Empty;
			try
			{
				addressDb.Entry(address).State = EntityState.Modified;
				addressDb.SaveChanges();
				result = "200";
			}
			catch
			{
				result = "400";
			}
			return result;
		}
		public string DeleteAddress(int id)
		{
			string result = string.Empty;
			Address? address;
			try
			{
				address = addressDb.Address.Find(id);
				if (address != null)
				{
					//package.Status = "In Active";
					addressDb.Address.Remove(address);
					addressDb.SaveChanges();
					result = "200";
				}
			}
			catch (Exception)
			{
				result = "400";
			}
			finally
			{
				address = null;
			}
			return result;
		}
	}
}
