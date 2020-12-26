using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Business.Models.Fornecedores;
using DevIO.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace DevIO.AppMVC.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedoresController()
        {
            _fornecedorService = new FornecedorService(new FornecedorRepository(), new EnderecoRepository());
        }
        // GET: Fornecedores
        public async Task<ActionResult> Index()
        {
            var Fornecedor = new Fornecedor()
            {

                Nome = "Matheus",
                Ativo = true,
                Documento = "47425796821",
                TipoFornecedor = TipoFornecedor.PessoaFisica,
                Endereco = new Endereco() { Logradouro = "213s", Numero = "202", Cidade = "Teste", Estado = "Teste", Bairro = "Teste", Cep = "09931040", Complemento = "cas", }

            };

            await _fornecedorService.Adicionar(Fornecedor);

            return new EmptyResult();
        }
    }
}