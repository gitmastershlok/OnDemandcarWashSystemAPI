using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Interfaces;


namespace OnDemandcarWashSystemAPI.Services
{
	public class ViewInvoiceService
	{
		private IViewInvoice _repository;
		public ViewInvoiceService(IViewInvoice repository)
		{
			_repository = repository;
		}
		public List<Invoice> ViewInvoice(int id)
		{
			return _repository.ViewInvoiceAsync(id);
		}
	}
}
