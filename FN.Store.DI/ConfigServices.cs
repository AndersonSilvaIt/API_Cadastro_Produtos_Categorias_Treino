using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.DI
{
	public static class ConfigServices
    {

		//Pacote do Nuget
		//Adicionar as dependências do Nuget
        public static void AddDependencies( this IServiceCollection services) {

			//Instancia Unica em todo o projeto
			//services.AddSingleton<StoreDataContext>();

			//Instância por requisição
			//services.AddScoped<StoreDataContext>();


			//Por chamada de método
			//services.AddTransient<StoreDataContext>();

			services.AddScoped<StoreDataContext>();
			services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
			services.AddTransient<ICategoriaRespository, CategoriaRepositoryEF>();
		}
    }
}
