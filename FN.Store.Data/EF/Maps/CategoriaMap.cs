﻿using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.Store.Data.EF.Maps
{
	public class CategoriaMap: IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder) {

			builder.ToTable(nameof(Categoria));

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Nome)
				.HasColumnType("varchar(100)")
				.IsRequired();

			builder.Property(x => x.Descricao)
				.HasColumnType("varchar(300)");

			builder.Property(x => x.DataCriacao);
			builder.Property(x => x.DataAlteracao);
		}
	}
}
