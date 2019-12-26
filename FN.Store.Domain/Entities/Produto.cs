using System;

namespace FN.Store.Domain.Entities
{
	public class Produto : Entity
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public int CategoriaId { get; set; }
		public Categoria Categoria { get; set; }

		public void UpDate(string nome, decimal preco, int categoriaId) {
			this.Nome = nome;
			this.Preco = preco;
			this.CategoriaId = categoriaId;
		}
	}
}
