using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Services;

namespace OnDemandcarWashSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ViewInvoiceController : ControllerBase
	{
		public readonly ViewInvoiceService _Service;

		public ViewInvoiceController(ViewInvoiceService service)
		{
			_Service = service;
		}

		[HttpGet]
		public List<Invoice> ViewInvoice(int id)
		{
			return _Service.ViewInvoice(id);
		}
	}
}
