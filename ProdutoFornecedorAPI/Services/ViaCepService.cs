using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ProdutoFornecedorAPI.Integration.Interfaces;
using ProdutoFornecedorAPI.Integration.Response;
using ProdutoFornecedorAPI.Integration.Refit;


namespace ProdutoFornecedorAPI.Services
{
    public class ViaCepService : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepService( IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.ObterDadosViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode){
                return responseData.Content;
            }
            return null;
        }
    }
}