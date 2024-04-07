using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Interfaces
{
	public interface IUnitOfWork:IAsyncDisposable 
	{
        public IGenericRepository<User> UsersRepository { get; set; }
        public Task<bool> SaveChanges();
	}
}
