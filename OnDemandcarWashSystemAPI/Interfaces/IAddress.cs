using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface IAddress
	{
		List<Address> GetAllAddress();
		Address GetAddress(int id);
		public string AddAddress(Address address);
		public string UpdateAddress(Address address);
		public string DeleteAddress(int id);
	}
}
