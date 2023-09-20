using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;


namespace OnDemandcarWashSystemAPI.Services
{
	public class OrderService
	{
		private IOrder _IOrder;
		public OrderService(IOrder Iorder)
		{
			_IOrder = Iorder;
		}
		public List<Order> GetAllOrder()
		{
			return _IOrder.GetAllOrder();
		}
		public Order GetOrder(int id)
		{
			return _IOrder.GetOrder(id);
		}
		public string AddOrder(Order order)
		{
			return _IOrder.AddOrder(order);
		}
		public string UpdateOrder(Order order)
		{
			return _IOrder.UpdateOrder(order);
		}
		public string DeleteOrder(int id)
		{
			return _IOrder.DeleteOrder(id);
		}
	}
}
