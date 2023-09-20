using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;


namespace OnDemandcarWashSystemAPI.Services
{
	public class AdminService
	{
		private IAdmin _IAdmin;
		public AdminService(IAdmin Iadmin)
		{
			_IAdmin = Iadmin;
		}
		public List<Admin> GetAllAdmin()
		{
			return _IAdmin.GetAllAdmin();
		}
		public Admin GetAdmin(int id)
		{
			return _IAdmin.GetAdmin(id);
		}
		public string AddAdmin(Admin admin)
		{
			return _IAdmin.AddAdmin(admin);
		}
		public string UpdateAdmin(Admin admin)
		{
			return _IAdmin.UpdateAdmin(admin);
		}
		public string DeleteAdmin(int id)
		{
			return _IAdmin.DeleteAdmin(id);
		}
	}
}
