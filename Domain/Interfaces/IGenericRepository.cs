using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Interfaces
{
	public interface IGenericRepository<TEntity> :IAsyncDisposable where TEntity : class
	{
		void Add(TEntity entity);

		Task<IEnumerable<TEntity>> ReadAllAsync();

		Task<bool> SaveChangesAsync();


	}
}
