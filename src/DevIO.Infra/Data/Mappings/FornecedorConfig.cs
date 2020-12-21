using DevIO.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Mappings
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor> 
    {
        public FornecedorConfig()
        {
            HasKey(f => f.Id);
            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("IX_DOCUMENTO", new IndexAnnotation(new IndexAttribute { IsUnique = true }))
                .IsFixedLength();

            HasRequired(x => x.Endereco)
                .WithRequiredPrincipal(e => e.Fornecedor);

            ToTable("Fornecedores");
        }
    }
}
