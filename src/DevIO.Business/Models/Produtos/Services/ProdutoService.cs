using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Core.Services;
using DevIO.Business.Models.Produtos.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {

        #region Dependência
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) :base(notificador)
        {
            _produtoRepository = produtoRepository;
        }
        #endregion
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            

            await _produtoRepository.Adicionar(produto);
        }

        public Task AtualizarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }


        public Task Remover(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
