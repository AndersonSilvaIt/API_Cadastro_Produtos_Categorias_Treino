using FN.Store.Api.Models;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Api.Controllers
{
	[Route("/api/v1/[controller]")]
	public class ProdutosController: ControllerBase {
		private readonly IProdutoRepository _produtoRepository;
		private readonly ICategoriaRespository _categoriaRespository;

		public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRespository categoriaRespository) {
			_produtoRepository = produtoRepository;
			_categoriaRespository = categoriaRespository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll() {

			var data = (await _produtoRepository.GetAllWithCategoriaAsync())
				.Select(p =>
				p.ToProdutoGet());

			return Ok(data);
		}

		[HttpGet("{id}", Name = "GetProdutoById")]
		public async Task<IActionResult> GetById(int id) {

			var data = await _produtoRepository.GetByIdWithCategoriaAsync(id);
			if(data == null)
				return NotFound(); // 404

			return Ok(data?.ToProdutoGet());
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody]ProdutoAddEdit model) {

			var categoria = await _categoriaRespository.GetAsync(model?.CategoriaId);

			if(categoria == null)
				ModelState.AddModelError("CategoriaId", "Categoria inválida");

			if(!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var data = model.ToProduto();
			_produtoRepository.Add(data);

			//data.Categoria.Nome = categoria.Nome;
			var produto = data.ToProdutoGet();
			produto.CategoriaNome = categoria.Nome;

			return CreatedAtRoute("GetProdutoById", new { produto.Id}, produto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult>UpDate(int id, [FromBody]ProdutoAddEdit model) {

			var categoria = await _categoriaRespository.GetAsync(model?.CategoriaId);

			if(categoria == null)
				ModelState.AddModelError("CategoriaId", "Categoria inválida");

			var produto = await _produtoRepository.GetAsync(id);
			if(produto == null)
				ModelState.AddModelError("Id", "Produto não localizado");

			produto.UpDate(model.Nome, model.Preco, model.CategoriaId);
			_produtoRepository.Update(produto);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) {

			var data = await _produtoRepository.GetAsync(id);
			if(data == null)
				return BadRequest(new { Produto = new string[] { "produto não localizado." } });

			_produtoRepository.Delete(data);

			return Ok();
		}

    }
}
