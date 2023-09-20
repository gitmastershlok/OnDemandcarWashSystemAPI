using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class CarRepository : ICar
	{
		private CarWashContext carDb;
		public CarRepository(CarWashContext carDbContext)
		{
			carDb = carDbContext;
		}
		public List<Car> GetAllCar()
		{
			List<Car> cars = null;
			try
			{
				cars = carDb.Cars.ToList();
			}
			catch (Exception) { }
			return cars;
		}
		public Car GetCar(int id)
		{
			Car? car;
			try
			{
				car = carDb.Cars.Find(id);
				if (car != null)
				{
					return car;
				}
			}
			catch (Exception)
			{
				throw new ArgumentNullException();
			}
			finally
			{
				car = null;
			}
			return car;
		}
		public string AddCar(Car car)
		{
			string result = string.Empty;
			try
			{
				carDb.Cars.Add(car);
				carDb.SaveChanges();
			}
			catch (Exception)
			{
				result = "400";
			}
			return result;
		}
		public string UpdateCar(Car car)
		{
			string result = string.Empty;
			try
			{
				carDb.Entry(car).State = EntityState.Modified;
				carDb.SaveChanges();
				result = "200";
			}
			catch
			{
				result = "400";
			}
			return result;
		}
		public string DeleteCar(int id)
		{
			string result = string.Empty;
			Car? car;
			try
			{
				car = carDb.Cars.Find(id);
				if (car != null)
				{
					//package.Status = "In Active";
					carDb.Cars.Remove(car);
					carDb.SaveChanges();
					result = "200";
				}
			}
			catch (Exception)
			{
				result = "400";
			}
			finally
			{
				car = null;
			}
			return result;
		}
	}
}
