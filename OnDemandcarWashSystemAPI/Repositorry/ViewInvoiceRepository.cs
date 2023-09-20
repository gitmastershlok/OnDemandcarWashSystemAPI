using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class ViewInvoiceRepository : IViewInvoice
	{
		CarWashContext context;
		public ViewInvoiceRepository(CarWashContext context) => this.context = context;
		public List<Invoice> ViewInvoiceAsync(int id)
		{
			try
			{
				var query = (from a in context.Orders
							 join b in context.Users
								 on a.CustId equals b.UserId
							 join d in context.Cars
								on a.CarId equals d.Id
							 join e in context.Packages
								on a.PackageId equals e.Id

							 select new Invoice()
							 {
								 CustomerName = b.UserName,
								 DateTime = a.DateTime,
								 PaymentStatus = a.PaymentStatus,
								 OrderTotal = a.TotalCost,
								 CarName = d.Name,
								 PackageName = e.Name
							 });
				List<Invoice> list1 = query.ToList();
				return list1;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}
		}
	}
}
