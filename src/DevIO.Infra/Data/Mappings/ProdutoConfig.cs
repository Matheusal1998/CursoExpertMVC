using DevIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Mappings
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(f => f.Id);
            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.Descricao)
           .IsRequired()
           .HasMaxLength(200);

            Property(f => f.Imagem)
           .IsRequired()
           .HasMaxLength(200);


            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.FornecedorId)
                ;


            ToTable("Produtos");
        }
    }
}
