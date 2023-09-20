using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface IViewInvoice
	{
		List<Invoice> ViewInvoiceAsync(int id);
	}
}
