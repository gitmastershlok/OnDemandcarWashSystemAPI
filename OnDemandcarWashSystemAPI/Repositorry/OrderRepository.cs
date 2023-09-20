using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class OrderRepository : IOrder
	{
		private CarWashContext orderDb;
		public OrderRepository(CarWashContext orderDbContext)
		{
			orderDb = orderDbContext;
		}
		public List<Order> GetAllOrder()
		{
			List<Order> orders = null;
			try
			{
				orders = orderDb.Orders.ToList();
			}
			catch (Exception) { }
			return orders;
		}
		public Order GetOrder(int id)
		{
			Order? order;
			try
			{
				order = orderDb.Orders.Find(id);
				if (order != null)
				{
					return order;
				}
			}
			catch (Exception)
			{
				throw new ArgumentNullException();
			}
			finally
			{
				order = null;
			}
			return order;
		}
		public string AddOrder(Order order)
		{
			string result = string.Empty;
			try
			{
				orderDb.Orders.Add(order);
				orderDb.SaveChanges();
			}
			catch (Exception)
			{
				result = "400";
			}
			return result;
		}
		public string UpdateOrder(Order order)
		{
			string result = string.Empty;
			try
			{
				orderDb.Entry(order).State = EntityState.Modified;
				orderDb.SaveChanges();
				result = "200";
			}
			catch
			{
				result = "400";
			}
			return result;
		}
		public string DeleteOrder(int id)
		{
			string result = string.Empty;
			Order? order;
			try
			{
				order = orderDb.Orders.Find(id);
				if (order != null)
				{
					//package.Status = "In Active";
					orderDb.Orders.Remove(order);
					orderDb.SaveChanges();
					result = "200";
				}
			}
			catch (Exception)
			{
				result = "400";
			}
			finally
			{
				order = null;
			}
			return result;
		}
	}
}
