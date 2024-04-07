using _3S.Task.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Task.Domain.Interfaces;

namespace _3S.Task.Persistence.Repositories
{

	public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class 
	{
		private readonly ApplicationReadDbContext _readdDbContext;
		private readonly ApplicationWriteDbContext _writeDbContext;
		
		public GenericRepository(ApplicationReadDbContext readDbContext,ApplicationWriteDbContext writeDbContext)
        {
			this._readdDbContext = readDbContext;
			this._writeDbContext = writeDbContext;
		}

		public void Add(TEntity entity)
		=> _writeDbContext.Set<TEntity>().Add(entity);

		public async ValueTask DisposeAsync()
		{
			await _writeDbContext.DisposeAsync();
			await _readdDbContext.DisposeAsync();
		}
		public async Task<IEnumerable<TEntity>> ReadAllAsync()
		=> await _readdDbContext.Set<TEntity>().AsNoTracking().ToListAsync();

		public async Task<bool> SaveChangesAsync()
		=> await _writeDbContext.SaveChangesAsync() > 0 ;
	}
}
