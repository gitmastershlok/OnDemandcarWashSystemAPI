using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface IOrder
	{
		List<Order> GetAllOrder();
		Order GetOrder(int id);
		public string AddOrder(Order order);
		public string UpdateOrder(Order order);
		public string DeleteOrder(int id);
	}
}
