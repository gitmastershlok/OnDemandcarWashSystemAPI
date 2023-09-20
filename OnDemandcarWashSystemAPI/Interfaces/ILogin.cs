namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface ILogin<TEntity, TKey> where TEntity : class
	{
		Task<int> Login(TEntity item);
	}
}
