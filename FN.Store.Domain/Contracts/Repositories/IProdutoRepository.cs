using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
		
		Task<IEnumerable<Produto>> GetByName(string name);
		Task<IEnumerable<Produto>> GetAllWithCategoriaAsync();
		 
		Task<Produto> GetByIdWithCategoriaAsync(int id);
	}
}
