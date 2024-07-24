using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutoFornecedorAPI.Integration.Response;

namespace ProdutoFornecedorAPI.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}