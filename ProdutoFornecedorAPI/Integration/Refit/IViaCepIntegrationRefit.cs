using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutoFornecedorAPI.Integration.Response;
using Refit;

namespace ProdutoFornecedorAPI.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);

    }
}