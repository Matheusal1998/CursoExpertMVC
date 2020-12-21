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
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(f => f.Id);
            Property(f => f.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(f => f.Numero)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();


            Property(f => f.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .IsFixedLength();

            Property(f => f.Estado)
                .IsRequired()
                .HasMaxLength(100)
                .IsFixedLength();


            Property(f => f.Complemento)
                .IsRequired()
                .HasMaxLength(100)
                .IsFixedLength();

            ToTable("Enderecos");
        }
    }
}
